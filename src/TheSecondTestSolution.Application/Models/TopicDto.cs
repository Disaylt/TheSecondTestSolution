using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Application.Models
{
    public record class TopicDto
    {
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Пользователь должен содержать более 5 символов.")]
        public string By { get; init; } = string.Empty;

        [MinLength(10, ErrorMessage = "Пользователь должен содержать более 10 символов.")]
        public string Title { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Неверно введено значение счета.")]
        public int Score { get; init; }
    }
}
