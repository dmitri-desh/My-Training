
using System.Collections.Generic;
using System.Data.Entity;

namespace OnlineShop.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
            GetPrices().ForEach(p => context.Prices.Add(p));
        }
        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            { new Category { CategoryID = 19, CategoryName = "Acne / Skin Care",
                             Description = "Acne medications work by reducing oil production, speeding up skin cell turnover, fighting bacterial infection or reducing inflammation — which helps prevent scarring. With most prescription acne drugs, you may not see results for four to eight weeks, and your skin may get worse before it gets better. It can take many months or years for your acne to clear up completely.",
                             Products = {GetProductByProductId(1), GetProductByProductId(2)}
                           },
              new Category { CategoryID = 150, CategoryName = "Addison's Disease",
                             Description = "All treatment for Addison's disease involves hormone replacement therapy to correct the levels of steroid hormones your body isn't producing.",
                             Products = { GetProductByProductId(3), GetProductByProductId(4) }
                           },
              new Category { CategoryID = 5, CategoryName = "AIDS / HIV",
                             Description = "HIV medications can help lower your viral load, fight infections, and improve your quality of life. But even if you take them, you can still give HIV to others. They're not a cure for HIV.",
                             Products = new List<Product> {}
                           },
              new Category { CategoryID = 145, CategoryName = "Alcoholism",
                             Description = "While drinking alcohol is itself not necessarily a problem—drinking too much can cause a range of consequences, and increase your risk for a variety of problems.",
                             Products = new List<Product> {}
                           },
              new Category { CategoryID = 28, CategoryName = "Alzheimer's",
                             Description = "Although current medications cannot cure Alzheimer’s or stop it from progressing, they may help lessen symptoms, such as memory loss and confusion, for a limited time.",
                             Products = new List<Product> {}
                           }
            };
            return categories;
        }
        private static List<Product> GetProducts()
        {
            // static part of AffiliateURL = http://www.freedom-pharmacy.bz/BannerAdClicks.asp?AdID=2&AffID=1001&Page=Products2.asp?

            var products = new List<Product>
            { new Product { ProductID = 1, BrandName = "A-Ret Gel", GenericName = "Tretinoin", Manufacturer = "Shalak",
                            Description = "This medication is used to treat acne. It may decrease the number and severity of acne pimples and promote quick healing of pimples that do develop. Tretinoin belongs to a class of medications called retinoids. It works by affecting the growth of skin cells. How to use Tretinoin Top Read the Patient Information Leaflet if one is available from your pharmacist. Consult your doctor or pharmacist if you have questions. Wash your hands before applying this medication. Gently clean the affected skin with a mild or soapless cleanser and pat dry. Use your fingertips to apply a small amount of medication (about the size of a pea) in a thin layer, usually once daily at bedtime or as directed by your doctor. A gauze pad or cotton swab can be used to apply the liquid. For some preparations, you should wait 20-30 minutes after cleaning your face before applying this medication. Consult the label directions, the Patient Information Leaflet, or your pharmacist if you have any questions. Use this medication on the skin only. Do not apply to the inner lip area or inside the nose/mouth. Do not apply to cut, scraped, sunburned, or eczema-affected skin. Avoid getting this medication in your eyes. If this medication gets into your eyes, flush with large amounts of water. Call your doctor if eye irritation develops. Wash your hands after using the medication to avoid accidentally getting it in your eyes. During the first few weeks of using tretinoin, your acne might appear worse because the medication is working on pimples forming inside the skin. It may take up to 8-12 weeks to notice results from this medication. Use it regularly in order to get the most benefit from it. To help you remember, use it at the same time each day. Do not use a larger amount or use it more frequently than recommended. Your skin will not improve any faster, and it will increase the risk of developing redness, peeling and pain. This medication is available in different strengths and forms (e.g., gel, cream, solution). The best type of medication for you to use will depend on the condition of your skin and your response to therapy. Inform your doctor if your condition persists or worsens.",
                            Prices = {GetPriceByPriceId(1), GetPriceByPriceId(2), GetPriceByPriceId(3), GetPriceByPriceId(4), GetPriceByPriceId(5), GetPriceByPriceId(6),
                                                      GetPriceByPriceId(7), GetPriceByPriceId(8)
                                                     },
                            AffiliateURL = "Brand=A%2DRet+Gel+%28+Retin%2DA%2C+Generic+Tretinoin+%29&T=a&ID=",
                            Categories = {GetCategoryByCategoryId(19)}
                          },
              new Product { ProductID = 2, BrandName = "ACERET", GenericName = "Acitretin", Manufacturer = "Glenmark",
                            Description = "This medication is a retinoid used in the treatment of severe psoriasis and other skin disorders in adults. How to use Acitretin Oral Read the Medication Guide provided by your pharmacist before you start using acitretin and each time you get a refill. If you have any questions regarding the information, consult your doctor or pharmacist. Read and complete the Patient Agreement and Informed Consent document before taking this drug. Take this medication by mouth exactly as prescribed, usually once a day with your main meal. The dosage is based on your medical condition and response to therapy. Do not take this more often or increase your dose without consulting your doctor. Your condition will not improve any faster but the risk of side effects may increase. It may take 2 to 3 months before the full benefit of this medication is seen. Use this medication regularly in order to get the most benefit from it. Remember to use it at the same time each day. What conditions does this medication treat? Acitretin Oral is used to treat the following: Severe Psoriasis that is Resistant to Treatment Acitretin Oral may also be used to treat: A Group of Lymphomas of the Skin, Skin Disease Characterized by Swollen Itching Lesions, Ichthyosis Lamellar, Ichthyosiform Erythroderma, A Rare Hereditary Skin Condition.",
                            Prices = {GetPriceByPriceId(9), GetPriceByPriceId(10), GetPriceByPriceId(11) },
                            AffiliateURL = "Brand=ACERET+%28+Soriatane%2C+Generic+Acitretin+%29&T=a&ID=",
                            Categories = {GetCategoryByCategoryId(19)}
                          },
              new Product { ProductID = 3, BrandName = "FLORICOT", GenericName = "Fludrocortisone", Manufacturer = "SAMARTH",
                            Description = "Fludrocortisone, a corticosteroid, is used to help control the amount of sodium and fluids in your body. It is used to treat Addison's disease and syndromes where excessive amounts of sodium are lost in the urine. It works by decreasing the amount of sodium that is lost (excreted) in your urine. Fludrocortisone comes as a tablet to be taken by mouth. Your doctor will prescribe a dosing schedule that is best for you. Follow the directions on your prescription label carefully, and ask your doctor or pharmacist to explain any part you do not understand. Take fludrocortisone exactly as directed. Do not take more or less of it or take it more often than prescribed by your doctor. Do not stop taking fludrocortisone without talking to your doctor. Stopping the drug abruptly can cause loss of appetite, an upset stomach, vomiting, drowsiness, confusion, headache, fever, joint and muscle pain, peeling skin, and weight loss. If you take large doses for a long time, your doctor probably will decrease your dose gradually to allow your body to adjust before stopping the drug completely. Watch for these side effects if you are gradually decreasing your dose and after you stop taking the tablets. If these problems occur, call your doctor immediately. You may need to increase your dose temporarily or start taking the tablets again. Fludrocortisone is also used to increase blood pressure.",
                            Prices = {GetPriceByPriceId(12) },
                            AffiliateURL = "Brand=FLORICOT+%28+Florinef%2C+Generic+Fludrocortisone+%29&T=m&ID=",
                            Categories = {GetCategoryByCategoryId(150)}
                          },
              new Product { ProductID = 4, BrandName = "Floricot", GenericName = "Fludrocortisone", Manufacturer = "Samarth Pharma",
                            Description = "Fludrocortisone is a man-made form of a natural substance (glucocorticoid) made by the body. It is used along with other medications (e.g., hydrocortisone) to treat low glucocorticoid levels caused by disease of the adrenal gland (e.g., Addison's disease, adrenocortical insufficiency, salt-losing adrenogenital syndrome). Glucocorticoids are needed in many ways for the body to function well. They are important for salt and water balance and keeping blood pressure normal. They are also needed to break down carbohydrates in your diet.",
                            Prices = {GetPriceByPriceId(13), GetPriceByPriceId(14), GetPriceByPriceId(15) },
                            AffiliateURL = "Brand=Floricot+%28Florinef%2C+Generic+Fludrocortisone%29&T=a&ID=",
                            Categories = {GetCategoryByCategoryId(150)}
                          }
            };
            return products;
        }
        private static List<Price> GetPrices()
        {
            var prices = new List<Price>
            { // ------ A-Ret Gel  ProductID = 1 
              new Price { PriceID = 1, Dose = "0.05%w/w",  Measure = "gm",           Quantity = "20",     UnitPrice =  51.31, Currency = "USD"},
              new Price { PriceID = 2, Dose = "0.025%w/v", Measure = "gm",           Quantity = "20",     UnitPrice =  54.87, Currency = "USD"},
              new Price { PriceID = 3, Dose = "0.1%w/w",   Measure = "gm",           Quantity = "20",     UnitPrice =  64.14, Currency = "USD"},
              new Price { PriceID = 4, Dose = "0.025%w/v", Measure = "gm",           Quantity = "3 x 20", UnitPrice =  81.03, Currency = "USD"},
              new Price { PriceID = 5, Dose = "0.05%w/w",  Measure = "gm(3 x 20gm)", Quantity = "60",     UnitPrice =  81.96, Currency = "USD"},
              new Price { PriceID = 6, Dose = "0.1%w/w",   Measure = "gm(3 x 20gm)", Quantity = "60",     UnitPrice =  85.38, Currency = "USD"},
              new Price { PriceID = 7, Dose = "0.05%w/w",  Measure = "gm(6 x 20gm)", Quantity = "120",    UnitPrice = 115.92, Currency = "USD"},
              new Price { PriceID = 8, Dose = "0.025%w/v", Measure = "gm(6 x 20gm)", Quantity = "120",    UnitPrice = 116.52, Currency = "USD"},
              // ------ ACERET ProductID = 2
              new Price { PriceID =  9, Dose = "25mg", Measure = "Capsules", Quantity = "10", UnitPrice =  94.48, Currency = "USD"},
              new Price { PriceID = 10, Dose = "25mg", Measure = "Capsules", Quantity = "20", UnitPrice = 138.09, Currency = "USD"},
              new Price { PriceID = 11, Dose = "25mg", Measure = "Capsules", Quantity = "30", UnitPrice = 192.59, Currency = "USD"},
              // ------ FLORICOT ProductID = 3
              new Price { PriceID = 12, Dose = "100mcg", Measure = "(3 x 10) Tabs", Quantity = "30", UnitPrice = 60.69, Currency = "USD"},
              // ------ Floricot ProductID = 4
              new Price { PriceID = 13, Dose = "100mcg", Measure = "Tablets",          Quantity = "100", UnitPrice = 116.52, Currency = "USD"},
              new Price { PriceID = 14, Dose = "100mcg", Measure = "(2 x 100)Tablets", Quantity = "200", UnitPrice = 190.81, Currency = "USD"},
              new Price { PriceID = 15, Dose = "100mcg", Measure = "(4 x 100)Tablets", Quantity = "400", UnitPrice = 348.05, Currency = "USD"}
            };
            return prices;
        }
        private static Price GetPriceByPriceId(int id)
        {
            return GetPrices().Find(p => p.PriceID == id);
        }
        private static Product GetProductByProductId (int id)
        {
            return GetProducts().Find(p => p.ProductID == id);
        }
        private static Category GetCategoryByCategoryId (int id)
        {
            return GetCategories().Find(c => c.CategoryID == id);
        }
    }
}