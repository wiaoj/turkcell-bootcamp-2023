using KidegaClone.WebUI.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace KidegaClone.WebUI.Mvc.Extensions;
public static class StringExtensions {
    private const String controllerSuffix = nameof(Controller);

    public static String TrimControllerSuffix(this String controllerName) {
        return controllerName.EndsWith(controllerSuffix)
                        ? controllerName[..^controllerSuffix.Length]
                        : controllerName;
    }
}