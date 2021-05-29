
N-Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanılarak CRUD işlemlerinin yapıldığı, Angular Fronted arayüz https://github.com/NurhatMentes/RentCar-Frontend.git
<b>(Frontend yazılmaya devam etmektedir!!)</b> ile çalışan, Araç Kiralama iş yerlerine yönelik örnek bir proje.


<h3>Entities Layer</h3>
Veritabanı nesneleri için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır. Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.

📁Abstract
      📄 IEntity.cs (Ortak Kod Olduğu İçin Core Katmanına Aktarıldı.)

📁Concrete
      📄 Brand.cs
      📄 Car.cs
      📄 Color.cs
      📄 CarImage.cs
      📄 Customer.cs
      📄 Rental.cs
      
 📁DTOs
      📄 CarDetailDto.cs
      📄 UserForLoginDto.cs
      📄 UserForRegisterDto.cs



<h3>Business Layer</h3>
Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan Business Katmanı'nda Abstract, Concrete, Constans, DependecyResolvers ve ValidationRules olmak üzere beş adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.

📁Abstract
     📄 ICarService.cs
     📄 IColorService.cs
     📄 IBrandService.cs
     📄 IAuthService.cs
     📄 ICarImageService.cs
     📄 ICustomerService.cs
     📄 IRentalService.cs
     📄 IUserService.cs
     
📁Concrete
      📄 CarManager.cs
      📄 ColorManager.cs
      📄 BrandManager.cs
      📄 AuthManager.cs
      📄 CarImageManager.cs
      📄 CustomerManager.cs
      📄 RentalManager.cs
      📄 UserManager.cs

📁Constans
      📄 Messages.cs
      
📁DependecyResolvers
      📄 Autofac.cs

📁ValidationRules
      📁 FluentValidation
             📄 CarValidator.cs
             📄 ColorValidator.cs
             📄 BrandValidator.cs
             📄 CarImageValidator.cs
             📄 CustomerValidator.cs
             📄 RentalValidator.cs
             📄 UserValidator.cs
             
             
             
<h3>Data Access Layer</h3>
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.

📁Abstract
     📄 IBrandDal.cs
     📄 ICarDal.cs
     📄 IColorDal.cs
     📄 ICarImageDal.cs
     📄 ICustomerDal.cs
     📄 IRentalDal.cs
     📄 IUserDal.cs

📁Concrete
      📁 EntityFramework
             📄 EfBrandDal.cs
             📄 EfCarDal.cs
             📄 EfColorDal.cs
             📄 EfCarImageDal.cs
             📄 EfCustomerDal.cs
             📄 EfRentalDal.cs
             📄 EfUserDal.cs
             📄 NorthwindContext.cs
      📁 InMemory
             📄 InMemoryCarDal.cs        
             
             
    
<h3>Core Layer</h3>
Bir framework katmanı olan Core Katmanı'nda DataAccess, Entities, Utilities olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.

⚠ DİKKAT: .
Core Katmanı, diğer katmanları referans almaz.

📁DataAccess
     📄 IEntityRepository.cs
     📁 EntityFramework
           📄 EfEntityRepositoryBase.cs

📁Entities
     📄 IEntity.cs
     📄 IDto.cs

📁Utilities
      📁 Results
          📁 Abstract
                 📄 IResult.cs
                 📄 IDataResult.cs
          📁 Concrete
               📄 DataResult.cs
               📄 ErrorDataResult.cs
               📄 ErrorResult.cs
               📄 Result.cs
               📄 SuccessDataResult.cs
               📄 SuccessResult.cs


             
