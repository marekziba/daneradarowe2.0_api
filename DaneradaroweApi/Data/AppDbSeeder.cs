using DaneradaroweApi.Models;

namespace DaneradaroweApi.Data
{
    public class AppDbSeeder
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                using (var transaction = context.Database.BeginTransaction())
                {
                    #region Radars

                    Radar BRZ = new Radar()
                    {
                        FullName = "Brzuchania",
                        CodeName = "BRZ",
                        Lat = 50.39417F,
                        Lon = 20.07972F,
                        IsDoppler = true,
                        IsDP = true
                    };

                    Radar GDA = new Radar()
                    {
                        FullName = "Gdańsk",
                        CodeName = "GDA",
                        Lat = 54.38425F,
                        Lon = 18.45631F,
                        IsDoppler = true,
                        IsDP = false
                    };

                    Radar LEG = new Radar()
                    {
                        FullName = "Legionowo",
                        CodeName = "LEG",
                        Lat = 52.405219F,
                        Lon = 20.960911F,
                        IsDoppler = true,
                        IsDP = false
                    };

                    Radar PAS = new Radar()
                    {
                        FullName = "Pastewnik",
                        CodeName = "PAS",
                        Lat = 50.892F,
                        Lon = 16.0395F,
                        IsDoppler = true,
                        IsDP = true
                    };

                    Radar POZ = new Radar()
                    {
                        FullName = "Poznań",
                        CodeName = "POZ",
                        Lat = 52.41326F,
                        Lon = 16.79706F,
                        IsDoppler = true,
                        IsDP = false
                    };

                    Radar RAM = new Radar()
                    {
                        FullName = "Ramża",
                        CodeName = "RAM",
                        Lat = 50.15167F,
                        Lon = 18.72667F,
                        IsDoppler = true,
                        IsDP = true
                    };

                    Radar RZE = new Radar()
                    {
                        FullName = "Rzeszów",
                        CodeName = "RZE",
                        Lat = 50.11409F,
                        Lon = 22.03704F,
                        IsDoppler = true,
                        IsDP = true
                    };

                    Radar SWI = new Radar()
                    {
                        FullName = "Świdwin",
                        CodeName = "SWI",
                        Lat = 53.79028F,
                        Lon = 15.83111F,
                        IsDoppler = true,
                        IsDP = false
                    };

                    Radar[] radars =
                    {
                            BRZ,
                            GDA,
                            LEG,
                            PAS,
                            POZ,
                            RAM,
                            RZE,
                            SWI
                    };

                    if (!context.Radars.Any())
                    {
                        context.Radars.AddRange(radars);
                        context.SaveChanges();
                    }

                    #endregion

                    #region Scans

                    Scan doppler = new Scan() { name = "doppler", Range = 125, Numele = 10, Radars = radars.ToList() };
                    Scan classic = new Scan() { name = "classic", Range = 250, Numele = 10, Radars = radars.ToList() };

                    Scan[] scans = { doppler, classic };

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT \"Scans\" ON;");

                    if (!context.Scans.Any())
                    {
                        context.Scans.AddRange(scans);
                        context.SaveChanges();
                    }

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Scans OFF;");

                    #endregion

                    #region DataTypes

                    DataType dbz = new DataType() { Name = "dBZ" };
                    DataType v = new DataType() { Name = "V" };

                    DataType[] dtypes = { dbz, v };

                    if (!context.DataTypes.Any())
                    {
                        context.DataTypes.AddRange(dtypes);
                        context.SaveChanges();
                    }

                    #endregion

                    #region ProductTypes

                    ProductType ppi = new ProductType() { Name = "PPI", DefiningAttribute = "ElevationAngle" };
                    ProductType cappi = new ProductType() { Name = "CAPPI", DefiningAttribute = "Height" };
                    ProductType cmax = new ProductType() { Name = "CMAX"  };
                    ProductType eht = new ProductType() { Name = "EHT", DefiningAttribute = "ReflectivityThreshold"  };

                    ProductType[] productTypes = { ppi, cappi, cmax, eht };

                    if (!context.ProductTypes.Any())
                    {
                        context.AddRange(productTypes);
                        context.SaveChanges();
                    }

                    #endregion

                    #region Products

                    Product PPI0_5_dbz = new Product() { Name = "PPI 0.5°", ProductType = ppi, DataType = dbz, ElevationAngle = 0.5F, Radars = radars.ToList(), Scan = doppler };
                    Product PPI0_5_dbz_classic = new Product() { Name = "PPI 0.5°", ProductType = ppi, DataType = dbz, ElevationAngle = 0.5F, Radars = radars.ToList(), Scan = classic };
                    Product PPI0_5_v = new Product() { Name = "PPI 0.5°", ProductType = ppi, DataType = v, ElevationAngle = 0.5F, Radars = radars.ToList(), Scan = doppler };

                    Product[] products = { PPI0_5_dbz, PPI0_5_dbz_classic, PPI0_5_v };

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON;");

                    if (!context.Products.Any())
                    {
                        context.Products.AddRange(products);
                        context.SaveChanges();
                    }

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF;");

                    #endregion

                    #region Images

                    Image[] images =
                        {
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar = POZ,
                                Scan = doppler,
                                Product = PPI0_5_dbz
                            },
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar = POZ,
                                Scan = classic,
                                Product = PPI0_5_dbz
                            },
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar = BRZ,
                                Scan = doppler,
                                Product = PPI0_5_dbz
                            },
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar= BRZ,
                                Scan = classic,
                                Product = PPI0_5_dbz
                            },
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar = LEG,
                                Scan = doppler,
                                Product = PPI0_5_dbz
                            },
                            new Image() {
                                Id = Guid.NewGuid(),
                                Url = "https://daneradarowe.pl/img/POZ_125/2022033015435000dBZ.ppi_1.png",
                                Date = DateTime.UtcNow,
                                Radar = LEG,
                                Scan = classic,
                                Product = PPI0_5_dbz,
                            }
                        };

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Images ON;");

                    if (!context.Images.Any())
                    {
                        context.Images.AddRange(images);
                        context.SaveChanges();
                    }

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Images OFF;");

                    #endregion

                    transaction.Commit();
                }
            }
        }
    }
}
