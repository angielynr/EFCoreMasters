using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.DataLayer
{
    public class UdfMethods
    {

        public const string UdfAverageVotes = nameof(UdfMethods.AverageVotes);
        private readonly InventoryAppEfCoreContext _inventoryAppEfCoreContext;

        public static double? AverageVotes(int clientId) => null;

        public UdfMethods(InventoryAppEfCoreContext inventoryAppEfCoreContext)
        {
            _inventoryAppEfCoreContext = inventoryAppEfCoreContext;
        }

        public void CreateScalarUdfForAverageVotes()
        {
            _inventoryAppEfCoreContext.Database.ExecuteSqlRaw(
                    $"CREATE FUNCTION {UdfAverageVotes} (@clientId int)" +
                    @"  RETURNS float
                      AS
                      BEGIN
                          DECLARE @result as float
                          SELECT 
                                @result = AVG(CAST([NumStars] AS float))
                          FROM [dbo].[Review] AS r
                          WHERE r.clientId = @clientId
                      RETURN @result
                      END");
        }

    }


}
