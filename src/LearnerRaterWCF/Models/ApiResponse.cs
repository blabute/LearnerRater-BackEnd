﻿namespace LearnerRaterWCF.Models
{
    public class ApiResponse
    {
        public long? ID { get; set; }
        public long? Password { get; set; }
        public bool? Result { get; set; }
        public string ResponseMessage { get; set; }
    }
}