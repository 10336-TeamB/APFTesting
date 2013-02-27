﻿using APFTestingModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam {
    public class PossibleAnswer {
        public PossibleAnswer()
        {
        }

        public PossibleAnswer(IPossibleAnswer possibleAnswer)
        {
            Description = possibleAnswer.Description;
            Order = possibleAnswer.Order;
        }

        public string Description { get; set; }
        public int Order { get; set; }
    }
}