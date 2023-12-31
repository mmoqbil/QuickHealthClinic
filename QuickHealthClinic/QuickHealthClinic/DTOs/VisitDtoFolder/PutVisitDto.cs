﻿namespace QuickLifeCoachingClinic.DTOs.VisitDtoFolder
{
    public class PutVisitDto
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int MentorId { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
        public bool? Confirmed { get; set; }
    }
}
