// <copyright file="Word.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL.Models
{
    public class Word
    {
        public Word(int id, string text, string translation, int subjectId)
        {
            this.Id = id;
            this.Text = text;
            this.Translation = translation;
            this.SubjectId = subjectId;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }

        public int SubjectId { get; set; }
    }
}
