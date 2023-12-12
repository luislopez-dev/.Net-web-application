﻿namespace Business.Models;

public class Invoice
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientNit { get; set; }
    public float Discount { get; set; }
    public float Total { get; set; }
    public string PaymentMethod { get; set; }
}