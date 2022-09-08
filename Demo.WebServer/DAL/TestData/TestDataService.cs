﻿namespace Demo.WebServer.DAL.TestData;

public static class TestDataService
{
    public static Guid KiloUomId { get; } = new Guid("AE26996F-C516-405F-A6FE-E22E323C1F0A");
    public static Guid PieceUomId { get; } = new Guid("9976D3C9-BD08-4B02-B5A4-69132B3570F6");
    public static Guid MeatsCategoryId { get; } = new Guid("3A0A3018-34CF-4857-B1A1-D67C5514B374");
    public static Guid FruitsCategoryId { get; } = new Guid("75FB16C5-BAD0-4E5E-A35F-B32D5649D87A");
    public static Guid ClothesCategoryId { get; } = new Guid("BD7F369C-8D95-43BD-8128-FD9DD2819E91");

    public const string UserRole = "User";
    public const string AdminRole = "Admin";
}