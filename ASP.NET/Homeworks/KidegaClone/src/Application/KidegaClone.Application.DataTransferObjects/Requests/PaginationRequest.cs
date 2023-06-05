namespace KidegaClone.Application.DataTransferObjects.Requests;
public sealed record PaginationRequest(Int32 Page = 1, Int32 Size = 16);