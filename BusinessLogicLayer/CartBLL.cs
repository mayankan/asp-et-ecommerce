using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CartBLL
    {
        //DB Context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        public void addtoCart(CartCL cartCL)
        {
            dbcontext.Carts.Add(new Cart
                {
                    DateAdded=cartCL.dateAdded,
                    ShippingCost = cartCL.shippingCost,
                    Id=cartCL.id,
                    MemberId=cartCL.memberId,
                    DateModified=cartCL.dateModified,
                    IsDeleted=cartCL.isDeleted,
                });
            dbcontext.SaveChanges();
        }
        public CartCL viewCart(CartCL cartCL)
        {
            Cart query = (from type in dbcontext.Carts where type.MemberId==cartCL.memberId select type).FirstOrDefault();
            CartCL view = new CartCL()
            {
                id=query.Id,
                dateAdded=query.DateAdded,
                memberId=query.MemberId,
                shippingCost=query.ShippingCost
            };
            return view;
        }
        public Collection<CartProductCL> getProductsAddedInCart()
        {
            Collection<CartProductCL> products = new Collection<CartProductCL>();
            IQueryable<CartProduct> query = from x in dbcontext.CartProducts select x;
            foreach (CartProduct item in query)
            {
                products.Add(new CartProductCL
                {
                    cartId=item.CartId,
                    id=item.Id,
                    productId=item.ProductId,
                    quantity=item.Quantity
                });
            }
            return products;
        }
        public MemberCL getMemberbyCartId(int cartId)
        {
            Cart cartQuery = (from y in dbcontext.Carts where y.Id==cartId select y).FirstOrDefault();
            Member memberQuery = (from x in dbcontext.Members where x.Id == cartQuery.MemberId select x).FirstOrDefault();
            MemberCL memberCL = new MemberCL()
            {
                addressId = memberQuery.AddressId,
                email = memberQuery.Email,
                gender = memberQuery.Gender,
                id = memberQuery.Id,
                isDeleted = memberQuery.IsDeleted,
                isGuest = memberQuery.IsGuest,
                mobNo = memberQuery.MobileNumber,
                name = memberQuery.Name,
                password = memberQuery.Password,
                dateCreated = memberQuery.DateCreated,
                dateModified = memberQuery.DateModified
            };
            return memberCL;
        }
        public CartCL getCartbyId(int cartId)
        {
            Cart cartQuery = (from y in dbcontext.Carts where y.Id == cartId select y).FirstOrDefault();
            CartCL cartCL = new CartCL()
            {
                dateAdded=cartQuery.DateAdded,
                dateModified=cartQuery.DateModified,
                id=cartQuery.Id,
                isDeleted=cartQuery.IsDeleted,
                memberId=cartQuery.MemberId,
                shippingCost=cartQuery.ShippingCost
            };
            return cartCL;
        }
        public ProductCL getProductbyCartId(int cartId)
        {
            CartProduct cartProductQuery = (from x in dbcontext.CartProducts where x.Id == cartId select x).FirstOrDefault();
            Product productQuery = (from z in dbcontext.Products where z.Id == cartProductQuery.ProductId select z).FirstOrDefault();
            ProductCL productCL = new ProductCL()
            {
                brandId = productQuery.BrandId,
                categoryId = productQuery.CategoryId,
                codApplicable = productQuery.CODApplicable,
                dateCreated = productQuery.DateCreated,
                dateModified = productQuery.DateModified,
                description = productQuery.Description,
                dispatchTime = productQuery.DispatchTime,
                featureDetails = productQuery.FeatureDetails,
                Id = productQuery.Id,
                imageUrl = productQuery.ImageURL,
                isDeleted = productQuery.IsDeleted,
                keywordsMeta = productQuery.Keywords_Meta,
                name = productQuery.Name,
                price = productQuery.Price,
                shippingCharge = productQuery.ShippingCharge,
                isHot = productQuery.IsHot,
                stockQuantity = Convert.ToInt32(productQuery.StockQuantity),
                warranty = productQuery.Warranty,
                weight = productQuery.Weight,
            };
            return productCL;
        }
        public CartProductCL getCartProductByCartId(int cartId)
        {
            CartProduct query = (from x in dbcontext.CartProducts where x.CartId == cartId select x).FirstOrDefault();
            CartProductCL cartProductCL = new CartProductCL()
            {
                cartId = query.CartId,
                id = query.Id,
                productId = query.ProductId,
                quantity = query.Quantity,
            };
            return cartProductCL;
        }
        public Collection<ProductCL> getProductCollectionByCartId(int cartId)
        {
            IQueryable<Product> cartProductQuery = from x in dbcontext.CartProducts where x.CartId == cartId select x.Product;
            Collection<ProductCL> productcart = new Collection<ProductCL>();
            foreach (Product item in cartProductQuery)
            {
                productcart.Add(new ProductCL
                {
                    brandId = item.BrandId,
                    categoryId = item.CategoryId,
                    codApplicable = item.CODApplicable,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    description = item.Description,
                    dispatchTime = item.DispatchTime,
                    featureDetails = item.FeatureDetails,
                    Id = item.Id,
                    imageUrl = item.ImageURL,
                    isDeleted = item.IsDeleted,
                    keywordsMeta = item.Keywords_Meta,
                    name = item.Name,
                    price = item.Price,
                    shippingCharge = item.ShippingCharge,
                    isHot = item.IsHot,
                    stockQuantity = Convert.ToInt32(item.StockQuantity),
                    warranty = item.Warranty,
                    weight = item.Weight,
                });
            }
            return productcart;
        }
        public Collection<CartProductCL> getCartProductCollectionByCartId(int cartId)
        {
            IQueryable<CartProduct> cartProductQuery = from x in dbcontext.CartProducts where x.CartId == cartId select x;
            Collection<CartProductCL> productcart = new Collection<CartProductCL>();
            foreach (CartProduct item in cartProductQuery)
            {
                productcart.Add(new CartProductCL
                {
                    id=item.Id,
                    cartId=item.CartId,
                    productId=item.ProductId,
                    quantity=item.Quantity
                });
            }
            return productcart;
        }
    }
}