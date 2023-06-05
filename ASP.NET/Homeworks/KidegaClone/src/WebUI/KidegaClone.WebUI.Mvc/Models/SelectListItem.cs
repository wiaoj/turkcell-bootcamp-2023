using KidegaClone.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidegaClone.WebUI.Mvc.Models;
public sealed class SelectListItem<TSelectListItem> : SelectListItem where TSelectListItem : IResponse { }