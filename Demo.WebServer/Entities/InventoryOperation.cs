﻿using Demo.DAL;

namespace Demo.WebServer.Entities;

public class InventoryOperation : IEntity
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}
