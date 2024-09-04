
CREATE TABLE Trades (
    TradeId INT IDENTITY(1,1) PRIMARY KEY, 
    Value DECIMAL (18,2) NOT NULL,       
    ClientSector VARCHAR(10) NOT NULL
);

CREATE TABLE TradeCategories (
    TradeCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(20) UNIQUE NOT NULL 
);

INSERT INTO TradeCategories (CategoryName) VALUES 
('LOWRISK'), ('MEDIUMRISK'), ('HIGHRISK'), ('UNKNOWN'); 

CREATE TABLE CategorizedTrades (
    CategorizedTradeId INT IDENTITY(1,1) PRIMARY KEY,
    TradeId INT NOT NULL,   
    TradeCategoryId INT NOT NULL, 
    FOREIGN KEY (TradeId) REFERENCES Trades(TradeId),
    FOREIGN KEY (TradeCategoryId) REFERENCES TradeCategories(TradeCategoryId)
);

CREATE PROCEDURE CategorizeTradesProc
AS
BEGIN
    INSERT INTO CategorizedTrades (TradeId, TradeCategoryId)
    SELECT 
        t.TradeId, 
        CASE
            WHEN t.Value < 1000000 AND t.ClientSector = 'Public' THEN (SELECT TradeCategoryId FROM TradeCategories WHERE CategoryName = 'LOWRISK')
            WHEN t.Value >= 1000000 AND t.ClientSector = 'Public' THEN (SELECT TradeCategoryId FROM TradeCategories WHERE CategoryName = 'MEDIUMRISK')
            WHEN t.Value >= 1000000 AND t.ClientSector = 'Private' THEN (SELECT TradeCategoryId FROM TradeCategories WHERE CategoryName = 'HIGHRISK')
            ELSE (SELECT TradeCategoryId FROM TradeCategories WHERE CategoryName = 'UNKNOWN') 
        END AS TradeCategoryId
    FROM 
        Trades t;
END;
GO

-- Example Usage:
INSERT INTO Trades (Value, ClientSector) VALUES
(2000000, 'Private'),
(400000, 'Public'),
(500000, 'Public'),
(3000000, 'Public');

-- 2. Execute the stored procedure to categorize
EXEC CategorizeTradesProc;

SELECT 
    t.TradeId,
    tc.CategoryName
FROM 
    CategorizedTrades ct
JOIN 
    Trades t ON ct.TradeId = t.TradeId
JOIN 
    TradeCategories tc ON ct.TradeCategoryId = tc.TradeCategoryId;
