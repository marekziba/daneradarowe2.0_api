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

                    Radar POLCOMP = new Radar() { 
                        FullName = "Polska - mapa zbiorcza", 
                        CodeName = "POLCOMP",
                        Lat = null, 
                        Lon = null, 
                        IsComposite = true 
                    };

                    Radar BRZ = new Radar()
                    {
                        FullName = "Brzuchania",
                        CodeName = "BRZ",
                        Lat = 50.39417F,
                        Lon = 20.07972F,
                        IsComposite = false
                    };

                    Radar GDA = new Radar()
                    {
                        FullName = "Gdańsk",
                        CodeName = "GDA",
                        Lat = 54.38425F,
                        Lon = 18.45631F,
                        IsComposite= false
                    };

                    Radar LEG = new Radar()
                    {
                        FullName = "Legionowo",
                        CodeName = "LEG",
                        Lat = 52.405219F,
                        Lon = 20.960911F,
                        IsComposite = false
                    };

                    Radar PAS = new Radar()
                    {
                        FullName = "Pastewnik",
                        CodeName = "PAS",
                        Lat = 50.892F,
                        Lon = 16.0395F,
                        IsComposite = false
                    };

                    Radar POZ = new Radar()
                    {
                        FullName = "Poznań",
                        CodeName = "POZ",
                        Lat = 52.41326F,
                        Lon = 16.79706F,
                        IsComposite = false
                    };

                    Radar RAM = new Radar()
                    {
                        FullName = "Ramża",
                        CodeName = "RAM",
                        Lat = 50.15167F,
                        Lon = 18.72667F,
                        IsComposite = false
                    };

                    Radar RZE = new Radar()
                    {
                        FullName = "Rzeszów",
                        CodeName = "RZE",
                        Lat = 50.11409F,
                        Lon = 22.03704F,
                        IsComposite = false
                    };

                    Radar SWI = new Radar()
                    {
                        FullName = "Świdwin",
                        CodeName = "SWI",
                        Lat = 53.79028F,
                        Lon = 15.83111F,
                        IsComposite = false
                    };

                    Radar[] radars =
                    {
                            POLCOMP,
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

                    Scan doppler = new Scan() { Type = "doppler", Range = 125, Numele = 10, Radars = radars.ToList() };
                    Scan classic = new Scan() { Type = "classic", Range = 250, Numele = 10, Radars = radars.ToList() };

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

                    DataType dbz = new DataType() { Name = "dBZ", ScaleUrl = "assets/scales/dbz.cm", ValueMin = -31.5, ValueMax = 80 };
                    DataType v = new DataType() { Name = "V", ScaleUrl = "assets/scales/v.dbz", ValueMin = -40, ValueMax = 40 };

                    DataType[] dtypes = { dbz, v };

                    if (!context.DataTypes.Any())
                    {
                        context.DataTypes.AddRange(dtypes);
                        context.SaveChanges();
                    }

                    #endregion

                    #region Products

                    Radar[] singleRadars = {
                            BRZ,
                            GDA,
                            LEG,
                            PAS,
                            POZ,
                            RAM,
                            RZE,
                            SWI
                        };

                    Product ppi_v_doppler = new Product() { ProductType = "ppi", CodeName = "ppi_125_v", FullName = "PPI(V)", DataType = v, Radars = singleRadars.ToList(), Scan = doppler };
                    Product ppi_dbz_doppler = new Product() { ProductType = "ppi", CodeName = "ppi_125_dbz", FullName = "PPI(dBZ)", DataType = dbz, Radars = singleRadars.ToList(), Scan = doppler };
                    Product ppi_dbz_classic = new Product() { ProductType = "ppi", CodeName ="ppi_250_dbz", FullName = "PPI(dBZ)", DataType = dbz, Radars = singleRadars.ToList(), Scan = classic };

                    Product cappi_v_doppler = new Product() { ProductType = "cappi", CodeName = "cappi_125_v", FullName = "CAPPI(V)", DataType = v, Radars = singleRadars.ToList(), Scan = doppler };
                    Product cappi_dbz_doppler = new Product() { ProductType = "cappi", CodeName = "cappi_125_dbz", FullName = "CAPPI(dBZ)", DataType = dbz, Radars = singleRadars.ToList(), Scan = doppler };
                    Product cappi_dbz_classic = new Product() { ProductType = "cappi", CodeName = "cappi_250_dbz", FullName = "CAPPI(dBZ)", DataType = dbz, Radars = radars.ToList(), Scan = classic };

                    Product cmax_v_doppler = new Product() { ProductType = "cmax", CodeName = "cmax_125_v", FullName = "CMAX(V)", DataType = v, Radars = singleRadars.ToList(), Scan = doppler };
                    Product cmax_dbz_doppler = new Product() { ProductType = "cmax", CodeName = "cmax_125_dbz", FullName = "CMAX(dBZ)", DataType = dbz, Radars =singleRadars.ToList(), Scan = doppler };
                    Product cmax_dbz_classic = new Product() { ProductType = "cmax", CodeName = "cmax_250_dbz", FullName = "CMAX(dBZ)", DataType = dbz, Radars = radars.ToList(), Scan = classic };

                    Product[] products =
                    {
                        ppi_v_doppler,
                        ppi_dbz_doppler,
                        ppi_dbz_classic,
                        cappi_v_doppler,
                        cappi_dbz_doppler,
                        cappi_dbz_classic,
                        cmax_v_doppler,
                        cmax_dbz_doppler,
                        cmax_dbz_classic
                    };

                    if (!context.Products.Any())
                    {
                        context.Products.AddRange(products);
                        context.SaveChanges();
                    }

                    #endregion

                    #region ProductsVariant

                    List<ProductVariant> productVariants = new List<ProductVariant>();
                    
                    foreach(Radar radar in singleRadars)
                    {
                        double[] angles = { 0.5, 1.9, 3.6, 5.6 };
                        foreach (double elev in angles){
                            productVariants.Add(new ProductVariant()
                            {
                                Product = ppi_dbz_doppler,
                                Radar = radar,
                                PropertyName = "elevation",
                                PropertyValue = elev.ToString(),
                                PropertyUnit = "°"
                            });
                        }

                        foreach (double elev in angles)
                        {
                            productVariants.Add(new ProductVariant()
                            {
                                Product = ppi_v_doppler,
                                Radar = radar,
                                PropertyName = "elevation",
                                PropertyValue = elev.ToString(),
                                PropertyUnit = "°"
                            });
                        }

                        angles = new double[] { 0.5, 1.4, 2.4, 3.6 };
                        foreach (double elev in angles)
                        {
                            productVariants.Add(new ProductVariant()
                            {
                                Product = ppi_dbz_classic,
                                Radar = radar,
                                PropertyName = "elevation",
                                PropertyValue = elev.ToString(),
                                PropertyUnit = "°"
                            });
                        }

                        int[] heights = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000 };
                        Product[] cappis = { cappi_dbz_doppler, cappi_v_doppler, cappi_dbz_classic };
                        foreach(int height in heights)
                        {
                            foreach(Product cappi in cappis)
                            {
                                productVariants.Add(new ProductVariant()
                                {
                                    Product = cappi,
                                    Radar = radar,
                                    PropertyName = "height",
                                    PropertyValue = height.ToString(),
                                    PropertyUnit = "m"
                                });
                            }
                        }

                        productVariants.Add(new ProductVariant()
                        {
                            Product = cmax_v_doppler,
                            Radar = radar
                        });

                        productVariants.Add(new ProductVariant()
                        {
                            Product = cmax_dbz_doppler,
                            Radar = radar
                        });

                        productVariants.Add(new ProductVariant()
                        {
                            Product = cmax_dbz_classic,
                            Radar = radar
                        });
                    }

                    productVariants.AddRange(
                        new ProductVariant[]
                        {
                            new ProductVariant() { Product = cmax_dbz_classic, Radar = POLCOMP },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "1000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "2000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "3000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "4000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "5000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "6000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "7000", PropertyName = "height", PropertyUnit = "m" },
                            new ProductVariant() { Product = cappi_dbz_classic, Radar = POLCOMP, PropertyValue = "8000", PropertyName = "height", PropertyUnit = "m" },
                        }
                    );

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON;");

                    if (!context.ProductVariants.Any())
                    {
                        Console.WriteLine(productVariants);
                        context.ProductVariants.AddRange(productVariants);
                        context.SaveChanges();
                    }

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF;");

                    #endregion

                    #region Images

                    

                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Images OFF;");

                    #endregion

                    transaction.Commit();
                }
            }
        }
    }
}
