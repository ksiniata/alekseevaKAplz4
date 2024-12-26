﻿using System;
using System.Collections.Generic;

namespace Alekseeva.Models;

public partial class GuestService
{
    public int Id { get; set; }

    public int? ReservationId { get; set; }

    public int? RoomId { get; set; }

    public int? ServiceId { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;
}