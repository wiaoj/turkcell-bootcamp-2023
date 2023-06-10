# Proof Key for Code Exchange (PKCE) Akışı
## Genel Bakış
PKCE, OAuth 2.0'ın bir hibe türü olan Yetkilendirme Kodu Akışı'nın bir versiyonudur. PKCE, genellikle istemci sırrını güvenli bir şekilde saklayamayan, yerli veya tek sayfalık uygulamalar için kullanılır.

### Neden PKCE Kullanılır?

Yerli ve tek sayfalık uygulamaların yetkilendirme kodu akışıyla ilgili bazı ek güvenlik endişeleri vardır:

- Yerli uygulamalar:

    + Bir İstemci Sırrını güvenli bir şekilde saklayamaz. Uygulamanın ayrıştırılması İstemci Sırrını açığa çıkarır.
    + Yönlendirmeleri yakalamak için özel bir URL şeması kullanabilir (örn., MyApp://) bu potansiyel olarak kötü niyetli uygulamaların Yetkilendirme Sunucusundan bir Yetkilendirme Kodu almasına izin verebilir.

- Tek sayfalık uygulamalar:

    + İstemci Sırrını güvenli bir şekilde saklayamaz çünkü tüm kaynakları tarayıcıya açıktır.

Bu durumlar göz önüne alındığında, OAuth 2.0, bir Kod Doğrulayıcı (Code Verifier) adı verilen bir sır oluşturan bir uygulama tarafından oluşturulan bir PKCE versiyonunu sağlar. Bu sır, yetkilendirme sunucusu tarafından doğrulanabilir. Ayrıca, çağıran uygulama, bu Kod Doğrulayıcısının bir dönüştürme değeri olan Kod Meydan Okuması (Code Challenge) oluşturur ve bu değeri bir Yetkilendirme Kodu almak için HTTPS üzerinden gönderir. Bu sayede, kötü niyetli bir saldırgan sadece Yetkilendirme Kodunu ele geçirebilir ve bu kodu bir token ile değiştiremez.

## Nasıl Çalışır

![oauth0](https://images.ctfassets.net/cdy7uua7fh8z/3pstjSYx3YNSiJQnwKZvm5/33c941faf2e0c434a9ab1f0f3a06e13a/auth-sequence-auth-code-pkce.png "Auth0 akışı")

PKCE ile geliştirilmiş Yetkilendirme Kodu Akışı, standart Yetkilendirme Kodu Akışı üzerine inşa edilmiştir ve adımlar çok benzerdir:

1. Kullanıcı, uygulama içinde Giriş Yap'a tıklar.

2. Auth0 SDK'sı, kriptografik olarak rastgele bir **code_verifier** oluşturur ve bununla **code_challenge** üretir.

3. Auth0 SDK'sı, kullanıcıyı **code_challenge** ile birlikte Auth0 Yetkilendirme Sunucusu'na (/authorize endpoint) yönlendirir.

4. Auth0 Yetkilendirme Sunucusu, kullanıcıyı giriş ve yetkilendirme istemine yönlendirir.

5. Kullanıcı, yapılandırılmış giriş seçeneklerinden birini kullanarak kimlik doğrular ve Auth0'un uygulamaya vereceği izinleri listeleyen bir onay sayfası görebilir.

6. Auth0 Yetkilendirme Sunucusu, **code_challenge**'ı saklar ve kullanıcıyı, bir kullanım için geçerli olan yetkilendirme code'u ile uygulamaya geri yönlendirir.

7. Auth0 SDK'sı, bu code'u ve **code_verifier**'i (2. adımda oluşturuldu) Auth0 Yetkilendirme Sunucusu'na (/oauth/token endpoint) gönderir.

8. Auth0 Yetkilendirme Sunucusu, **code_challenge**'ı ve **code_verifier**'i doğrular.

9. Auth0 Yetkilendirme Sunucusu, bir ID token ve erişim token'ı (ve isteğe bağlı olarak, bir yenileme token'ı) ile yanıt verir.

10. Uygulamanız, kullanıcı hakkında bilgiye erişmek için bir API'yi çağırmak üzere erişim token'ını kullanabilir.

11. API, istenen verilerle yanıt verir.

Eğer Yenileme Token Rotasyonu etkinleştirilmişse, her taleple birlikte yeni bir Yenileme Token'ı oluşturulur ve Erişim Token'ı ile birlikte verilir. Bir Yenileme Token'ı değiştirildiğinde, önceki Yenileme Token'ı geçersiz kılınır ancak ilişki hakkındaki bilgi yetkilendirme sunucusu tarafından saklanır.

## Nasıl Uygulanır
PKCE ile Yetkilendirme Kodu Akışını uygulamanın en kolay yolu, Native Quickstarts'ı veya Single-Page Quickstarts'ı takip etmektir, biz burada ASP.NET Core (MVC) seçeneğiyle ilerleyeceğiz.

Auth0, uygulamanıza hızlı bir şekilde kimlik doğrulama eklemenizi ve kullanıcı profil bilgilerine erişmenizi sağlar. Bu rehberde **Auth0.AspNetCore.Authentication SDK**'sı kullanılarak Auth0'ın nasıl entegre edileceği gösterilmektedir

Uygulama türünüze bağlı olarak, aşağıdaki SDK'ları kullanabilirsiniz:

- Mobil
    - Auth0 Swift SDK
    - Auth0 Android SDK

- Single-page
    - Auth0 Single-Page App SDK
    - Auth0 React SDK


> **⚠️**
>
> Son zamanlarda, tarayıcılardaki kullanıcı gizlilik kontrollerindeki ilerlemeler, üçüncü taraf çerezlerine erişimi engelleyerek kullanıcı deneyimini olumsuz etkiler; bu yüzden, tarayıcı tabanlı akışlar, kullanıcıların kaynaklara kesintisiz erişimini sağlarken SPAlarda yenileme token'larını güvenli bir şekilde kullanmak için Yenileme Token Rotasyonunu kullanmalıdır.


Auth0, hızlı bir şekilde hemen hemen her türde uygulamaya kimlik doğrulama eklemenize ve kullanıcı profil bilgilerine erişmenize olanak sağlar. Bu rehberde, **Microsoft.AspNetCore.Authentication.JwtBearer** paketini kullanarak Auth0'un yeni veya mevcut bir ASP.NET Web API uygulamasıyla nasıl entegre edileceğini inceleyeceğiz​.

Öncelikle Auth0, kullanıcının bir erişim belirteci ile nasıl kaynaklara erişebileceğini tanımlamasına olanak sağlar. Örneğin, messages kaynağına okuma erişimi sağlamayı ve yönetici erişim seviyesine sahip kullanıcılara da bu kaynağa yazma erişimi sağlamayı seçilebilir. Bu yetkiler, Auth0 Dashboard'un APIs bölümündeki Permissions görünümünde tanımlanabir.


1. Erişim belirtecini doğrulamanıza olanak sağlamak için ilgili Nuget paketini projeye eklemelisiniz:

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

2. Uygulamanızın Program.cs dosyasında kimlik doğrulama ara yazılımını ayarlayın.

    - Kimlik doğrulama hizmetlerini kaydedin. Bunu, AddAuthentication metoduna bir çağrı yaparak gerçekleştiririz ve JwtBearerDefaults.AuthenticationScheme'i varsayılan şema olarak ayarlarız.

    - JWT Bearer kimlik doğrulama şemasını kaydedin. Bunu, AddJwtBearer metoduna bir çağrı yaparak gerçekleştiririz. Burada Auth0 domain'inizi yetkililik olarak ve Auth0 API Identifier'ınızı izleyici olarak ayarlamalısınız. Auth0 domain'iniz ve API Identifier'ınızın uygulamanızın **appsettings.json** dosyasında ayarlandığından emin olun.

    - Kimlik doğrulama ve yetkilendirme ara yazılımlarını ara yazılım pipeline'ına ekleyin. Bunu, **UseAuthentication** ve **UseAuthorization** metodlarına çağrılar ekleyerek yapabiliriz.

3. Doğru kapsamların bir erişim belirtecinde bulunduğundan emin olmak için ASP.NET Core'da Politika Tabanlı Yetkilendirmeyi kullanın.

4. Endpoint'leri güvence altına almak için, **[Authorize]** niteliğini controller eyleminize ekleyin. Belirli kapsamları gerektiren endpoint'leri korurken, doğru kapsamın **access_token** içinde bulunduğundan emin olun. Bunu yapmak için, Authorize niteliğini Scoped eyleme ekleyin ve **read:messages**'i policy parametresi olarak geçirin.

API'nizi çağırma şekliniz, geliştirdiğiniz uygulama türüne ve kullandığınız çerçeveye bağlıdır. API'nizi çağırmak için bir erişim belirtecine ihtiyacınız vardır. API'nizi bir Tek Sayfalık Uygulama (SPA) veya Yerel bir uygulamadan çağırıyorsanız, yetkilendirme akışı tamamlandıktan sonra bir erişim belirteci alırsınız. API'nizi bir komut satırı aracından veya bir kullanıcının kimlik bilgilerini giremediği başka bir hizmetten çağırıyorsanız, OAuth Client Credentials Flow'u kullanın.

Bu adımların kod örnekleri için, öncelikle AddAuthentication ve AddJwtBearer'ı projeme nasıl eklerim derseniz aşağıdaki kod bloğunu inceleyebilirsiniz.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options => {
        options.Authority = "{AUTH0_DOMAIN}";
        options.Audience = "{AUTH0_API_IDENTIFIER}";
    });
    
    services.AddControllers();
}
```

Bu örnekte, AddAuthentication çağrısı, varsayılan kimlik doğrulama şemasını **JwtBearerDefaults.AuthenticationScheme** olarak ayarlar. AddJwtBearer çağrısı, JWT Bearer kimlik doğrulama şemasını kaydeder ve Auth0 domain'inizi yetkililik olarak ve Auth0 API Identifier'ınızı izleyici olarak ayarlar.

Bununla birlikte, bu örneğin çalışması için öncelikle Auth0'da bir API oluşturmanız ve ardından ilgili API'yi uygulamanızla ilişkilendirmeniz gerekir. Auth0'da API oluşturma ve yönetmeyle ilgili ayrıntılı adımlar için Auth0 dokümantasyonuna bakabilirsiniz. Bu süreç, API'nin Auth0 API Identifier'ını ve domain'ini elde etmeyi içerir, bu bilgiler daha sonra AddJwtBearer çağrısında kullanılır.

Ayrıca, endpoint'lerinizi korumak için [Authorize] niteliğini kullanabilirsiniz. Örneğin, belirli bir kapsama sahip bir kullanıcının bir eylemi yürütmesine izin vermek istiyorsanız, aşağıdaki gibi bir şey yapabilirsiniz:

```csharp
[Authorize("read:messages")]
public IActionResult MyAction() { }
```

Bu örnekte, **read:messages** politikasına sahip herhangi bir kullanıcının MyAction eylemini yürütmesine izin verilir. Bu politika, Auth0'da tanımlanmış bir kapsamı temsil eder.

## Yararlanılan kaynaklar
- https://auth0.com/docs
- https://chat.openai.com