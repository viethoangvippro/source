using Project.Data.Enums;
using Project.Models;

namespace Project.Data
{
    public class AppDbInit
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            { 
                var context  = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinestar Huế",
                            Logo = "https://hcm01.vstorage.vngcloud.vn/v1/AUTH_0e0c1e7edc044168a7f510dc6edd223b/media-prd/cache/square/59a2a1753d6416c84b4e05146280584a33448c14.png",
                            Description ="25 Hai Bà Trưng, P. Vĩnh Ninh, Tp. Huế"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Trấn Thành",
                            Picture = "https://ims.baoyenbai.com.vn/NewsImg/1_2023/_nhabaonu.jpg",
                            Description ="Huỳnh Trấn Thành, nổi tiếng với nghệ danh Trấn Thành, là một nam nghệ sĩ hài, người dẫn chương trình kiêm diễn viên điện ảnh và nhà làm phim người Việt Nam"
                        }
                    });
                    context.SaveChanges();
                }
               
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Trấn Thành",
                            Picture = "https://ims.baoyenbai.com.vn/NewsImg/1_2023/_nhabaonu.jpg",
                            Description ="Huỳnh Trấn Thành, nổi tiếng với nghệ danh Trấn Thành, là một nam nghệ sĩ hài, người dẫn chương trình kiêm diễn viên điện ảnh và nhà làm phim người Việt Nam"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name ="Nhà bà nữ",
                            Description ="The House of No Man",
                            Price = 45.5,
                            ImageURl="https://upload.wikimedia.org/wikipedia/vi/thumb/6/6f/%C3%81p_ph%C3%ADch_phim_Nh%C3%A0_b%C3%A0_N%E1%BB%AF.jpg/220px-%C3%81p_ph%C3%ADch_phim_Nh%C3%A0_b%C3%A0_N%E1%BB%AF.jpg",
                            StartDay = DateTime.Now.AddDays(-10),
                            EndDay = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Comendy
                        }
                    });
                    context.SaveChanges();
                }
                //Actors_Movies
             /*  if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                    });
                    context.SaveChanges();
                }*/
            }
        }
    }
}
