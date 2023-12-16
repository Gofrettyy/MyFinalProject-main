namespace Business.Constants;

public static class Messages //burası sabit olduğu için statik
{
 public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
 public static string ProductNameAlreadyExists = "Ürün zaten mevcut";
 public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
 public static string? ProductAdded = "Ürün eklendi";
 public static string? ProductNameInvalid = "Ürün ismi geçersiz.";
 public static string? MaintenanceTime = "Sistem bakımda";
 public static string ProductsListed = "Ürünler Listelendi.";
 public static string AuthorizationDenied = "Yetkilendirme Reddedildi.";
}