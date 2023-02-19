﻿using Meetup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infrastructure.Dtos.Meeting
{
    internal class MeetingDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? MeetingTime { get; set; }

        public int SpeakerId { get; set; }
        public List<Sponsor>? Sponsors { get; set; }
        public List<Participant>? Participants { get; set; }
    }
}