using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal struct Answer
    {
        #region Properties

        public int Id { get; set; }
        public string Text { get; set; }

        #endregion

        // --------------------------------------------------------------------------------------------------------------------

        public Answer(int _id, string _text)
        {
            Id = _id;
            Text = _text;
        }

        // --------------------------------------------------------------------------------------------------------------------

        // I Overrided The Equals Method To Compare Between The User's Answer And The Correct Answer

        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Answer answer && Id == answer.Id;


        }

        // --------------------------------------------------------------------------------------------------------------------

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }


        // --------------------------------------------------------------------------------------------------------------------


        public override readonly string ToString()
        {
            return $"Answer Id: {Id}\nAnswer Text: {Text}";
        }

        // --------------------------------------------------------------------------------------------------------------------
    }
}

