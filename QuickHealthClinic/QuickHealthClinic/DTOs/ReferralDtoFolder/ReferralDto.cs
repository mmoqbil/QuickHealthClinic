﻿namespace QuickLifeCoachingClinic.DTOs.ReferralDtoFolder
{
    public class ReferralDto
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public int StudentId { get; init; }
        public long Date { get; set; }
        public string Specialist { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
