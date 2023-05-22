namespace DependencyInjectionLifeTime.Models;
public interface IGuidGenerator {
    Guid Guid { get; }
}

public interface ISingletonGuid : IGuidGenerator { }
public interface ITransientGuid : IGuidGenerator { }
public interface IScopedGuid : IGuidGenerator { }

public class SingletonGuid : ISingletonGuid {
    public Guid Guid { get; }
    public SingletonGuid() {
        this.Guid = Guid.NewGuid();
    }
}

public class TransientGuid : ITransientGuid {
    public Guid Guid { get; }
    public TransientGuid() {
        this.Guid = Guid.NewGuid();
    }
}

public class ScopedGuid : IScopedGuid {
    public Guid Guid { get; }
    public ScopedGuid() {
        this.Guid = Guid.NewGuid();
    }
}

public class GuidService {
    public ISingletonGuid Singleton { get; set; }
    public ITransientGuid Transient { get; set; }
    public IScopedGuid Scoped { get; set; }

    public GuidService(ISingletonGuid singleton, ITransientGuid transient, IScopedGuid scoped) {
        this.Singleton = singleton;
        this.Transient = transient;
        this.Scoped = scoped;
    }
}