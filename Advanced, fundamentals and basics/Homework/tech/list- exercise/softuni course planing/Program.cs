using System;
using System.Collections.Generic;
using System.Linq;

namespace softuni_course_planing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = Console.ReadLine();
            while (command != "course start")
            {
                List<string> token = command.Split(":").ToList();
                switch (token[0])
                {
                    case "Add":
                        AddLessno(lessons, token[1]);
                        break;
                    case "Insert":
                        InserLesson(lessons, token[1], token[2]);
                        break;
                    case "Remove":
                        RemoveLessons(lessons, token[1]);
                        break;
                    case "Swap":
                        SwapLessons(lessons, token[1], token[2]);
                        break;
                    case "Exercise":
                        AddExercise(lessons, token[1]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(string.Join(" ",lessons));
                command = Console.ReadLine();
            }
            for (int i = 1; i <= lessons.Count; i++)
            {
                Console.WriteLine($"{i}.{lessons[i-1]}");
            }
        }

        private static void RemoveLessons(List<string> lessons, string LessonTitle)
        {
            lessons.Remove(LessonTitle);
            if (lessons.Contains(LessonTitle + "-Exercise"))
                lessons.Remove(LessonTitle+"-Exercise");
        }

        private static void AddExercise(List<string> lessons, string lesonTitle)
        {
            int indexLesson = lessons.IndexOf(lesonTitle);
            if (lessons.Contains(lesonTitle))
                lessons.Insert(++indexLesson, lesonTitle + "-Exercise");
            else
            {
                lessons.Add(lesonTitle);
                lessons.Add(lesonTitle + "-Exercise");
            }
        }

        private static void SwapLessons(List<string> lessons, string firstLesson, string SecondLesson)
        {
            int firstIndex = lessons.IndexOf(firstLesson);
            int secondIndex = lessons.IndexOf(SecondLesson);
            if(lessons.Contains(firstLesson)&&lessons.Contains(SecondLesson))
            {
                lessons[firstIndex] = SecondLesson;
                if (lessons.Contains(firstLesson + "-Exercise"))
                {

                    lessons.Insert(secondIndex + 1, firstLesson + "-Exercise");
                    lessons.RemoveAt(firstIndex+1);
                }
                lessons[secondIndex] = firstLesson;
               
            }
        }

        private static void InserLesson(List<string> lessons, string lessonTitle, string index)
        {
            if (!lessons.Contains(lessonTitle))
                lessons.Insert(int.Parse(index), lessonTitle);
        }

        private static void AddLessno(List<string> lessons, string element)
        {
            if(!lessons.Contains(element))
            lessons.Add(element);
        }
    }
}
