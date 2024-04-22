using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.FavoriteProduct;
public class FavoriteProduct : BaseEntity
{
    #region Properties

    public int? UserId { get; set; }

    public int ProductId { get; set; }


    #endregion

    #region Navigation Properties

    public User.User User { get; set; }

    public Product.Product Product { get; set; }

    #endregion
}

