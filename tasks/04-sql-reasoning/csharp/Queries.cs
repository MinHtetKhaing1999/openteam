// tasks/04‑sql‑reasoning/csharp/Queries.cs
namespace SqlReasoning
{
    public static class Queries
    {
        public const string SQL_A = @"SELECT campaign_id, total_thb, ROUND(total_thb * 1.0 / target_thb,  4) pct_of_target FROM (
                                        SELECT c.id campaign_id, sum(p.amount_thb)  total_thb, c.target_thb from campaign c
                                        join pledge p on c.Id = p.campaign_id
                                        GROUP by c.id) ORDER by pct_of_target DESC, total_thb ;
";

        public const string SQL_B = @"WITH joined AS (
                                        SELECT p.amount_thb, d.country
                                        FROM pledge p
                                        JOIN donor d ON p.donor_id = d.id
                                        ),
                                        global_ranked AS (
                                        SELECT 
                                            'global' AS scope,
                                            amount_thb,
                                            ROW_NUMBER() OVER (ORDER BY amount_thb) AS rn,
                                            COUNT(*) OVER () AS total_rows
                                        FROM joined
                                        ),
                                        thailand_ranked AS (
                                        SELECT 
                                            'thailand' AS scope,
                                            amount_thb,
                                            ROW_NUMBER() OVER (ORDER BY amount_thb) AS rn,
                                            COUNT(*) OVER () AS total_rows
                                        FROM joined
                                        WHERE country = 'Thailand'
                                        ),
                                        percentiles AS (
                                        SELECT scope, amount_thb
                                        FROM global_ranked
                                        WHERE rn = CAST(CEIL(0.9 * total_rows) AS INT)

                                        UNION ALL

                                        SELECT scope, amount_thb
                                        FROM thailand_ranked
                                        WHERE rn = CAST(CEIL(0.9 * total_rows) AS INT)
                                        )
                                        SELECT scope, amount_thb AS p90_thb
                                        FROM percentiles
                                        ORDER BY scope;
";

        public static readonly string[] INDEXES = ["CREATE INDEX idx_pledge_campaign_id ON pledge(campaign_id);",
                                                    "CREATE INDEX idx_pledge_donor_id ON pledge(donor_id);"];   // skipped
    }
}
