using KidegaClone.Application.DataTransferObjects;
using KidegaClone.WebUI.Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidegaClone.WebUI.Mvc.Extensions;
public static class SelectListItemExtensions {
    public static SelectListItem<TEntity> ToSelectListItem<TEntity>(this TEntity selectListItem, String text, String value)
        where TEntity : IResponse {
        return new() {
            Text = text,
            Value = value
        };
    }
}