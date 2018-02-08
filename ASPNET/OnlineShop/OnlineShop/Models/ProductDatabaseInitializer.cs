
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
          //  GetPrices().ForEach(p => context.Prices.Add(p));
        }
        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            { new Category { CategoryID = 19, CategoryName = "Acne / Skin Care",
                             Description = "Acne medications work by reducing oil production, speeding up skin cell turnover, fighting bacterial infection or reducing inflammation — which helps prevent scarring. With most prescription acne drugs, you may not see results for four to eight weeks, and your skin may get worse before it gets better. It can take many months or years for your acne to clear up completely.",
                             Products = new List<Product> {}
                           },
              new Category { CategoryID = 150, CategoryName = "Addison's Disease",
                             Description = "All treatment for Addison's disease involves hormone replacement therapy to correct the levels of steroid hormones your body isn't producing.",
                             Products = new List<Product> {}
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
            var products = new List<Product>
            { new Product { ProductID = 1, BrandName = "A-Ret Gel", GenericName = "Tretinoin", Manufacturer = "Shalak",
                            Description = "This medication is used to treat acne. It may decrease the number and severity of acne pimples and promote quick healing of pimples that do develop. Tretinoin belongs to a class of medications called retinoids. It works by affecting the growth of skin cells. How to use Tretinoin Top Read the Patient Information Leaflet if one is available from your pharmacist. Consult your doctor or pharmacist if you have questions. Wash your hands before applying this medication. Gently clean the affected skin with a mild or soapless cleanser and pat dry. Use your fingertips to apply a small amount of medication (about the size of a pea) in a thin layer, usually once daily at bedtime or as directed by your doctor. A gauze pad or cotton swab can be used to apply the liquid. For some preparations, you should wait 20-30 minutes after cleaning your face before applying this medication. Consult the label directions, the Patient Information Leaflet, or your pharmacist if you have any questions. Use this medication on the skin only. Do not apply to the inner lip area or inside the nose/mouth. Do not apply to cut, scraped, sunburned, or eczema-affected skin. Avoid getting this medication in your eyes. If this medication gets into your eyes, flush with large amounts of water. Call your doctor if eye irritation develops. Wash your hands after using the medication to avoid accidentally getting it in your eyes. During the first few weeks of using tretinoin, your acne might appear worse because the medication is working on pimples forming inside the skin. It may take up to 8-12 weeks to notice results from this medication. Use it regularly in order to get the most benefit from it. To help you remember, use it at the same time each day. Do not use a larger amount or use it more frequently than recommended. Your skin will not improve any faster, and it will increase the risk of developing redness, peeling and pain. This medication is available in different strengths and forms (e.g., gel, cream, solution). The best type of medication for you to use will depend on the condition of your skin and your response to therapy. Inform your doctor if your condition persists or worsens."

                          }

            };
            return products;
        }
    }
}