﻿using StatisticsAnalysisTool.Common;
using System.Text.Json.Serialization;

namespace StatisticsAnalysisTool.Models.NetworkModel;

public class MailContent
{
    public int UsedQuantity { get; set; }
    public int Quantity { get; set; }
    public string UniqueItemName { get; set; }
    public long InternalTotalPrice { get; set; }
    public long InternalUnitPrice { get; set; }
    public double TaxRate { get; set; } = 0;
    [JsonIgnore]
    public bool IsTaxesStated => TaxRate > 0;
    [JsonIgnore]
    public FixPoint TotalPrice => FixPoint.FromInternalValue(InternalTotalPrice);
    [JsonIgnore]
    public FixPoint UnitPrice => FixPoint.FromInternalValue(InternalUnitPrice);
    [JsonIgnore]
    public FixPoint ActualUnitPrice => FixPoint.FromFloatingPointValue(FixPoint.FromInternalValue(InternalTotalPrice).DoubleValue / UsedQuantity);
    [JsonIgnore]
    public FixPoint TaxPrice => FixPoint.FromFloatingPointValue(FixPoint.FromInternalValue(InternalTotalPrice).DoubleValue / 100 * TaxRate);
    [JsonIgnore]
    public FixPoint TotalPriceWithDeductedTaxes => FixPoint.FromFloatingPointValue(FixPoint.FromInternalValue(InternalTotalPrice).DoubleValue * ((100 - TaxRate) / 100));
    [JsonIgnore]
    public FixPoint UnitPriceWithDeductedTaxes => FixPoint.FromFloatingPointValue(FixPoint.FromInternalValue(InternalUnitPrice).DoubleValue * ((100 - TaxRate) / 100));
}