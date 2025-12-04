using Microsoft.EntityFrameworkCore;
public class QuizService
{
    private readonly QuizDbContext _context;

    public QuizService(QuizDbContext context)
    {
        _context = context;
    }

    public QuizQuestion[] GetQuiz()
    {
        return _context.QuizQuestions.ToArray();
    }



    public CatPersona[] GetCatPersonas()
    {
        return _context.CatPersonas.ToArray();
    }



    public QuizResult CalculateResult(SubmissionDto submission)
    {
        var catPersonas = GetCatPersonas();
        var personaNames = catPersonas.Select(p => p.Name).ToArray();


        var mapping = new Dictionary<int, int[]>
    {
        { 1, new[] { 0, 1, 2, 3, 4 } },
        { 2, new[] { 0, 1, 2, 3, 4 } },
        { 3, new[] { 0, 1, 2, 3, 4 } },
        { 4, new[] { 0, 1, 2, 3, 4 } },
        { 5, new[] { 0, 1, 2, 3, 4 } },
    };


        var scores = personaNames.ToDictionary(name => name, _ => 0);

        if (submission?.Answers is not { Length: > 0 })
            return new QuizResult(catPersonas.First(), scores);

        foreach (var answer in submission.Answers)
        {
            if (!mapping.TryGetValue(answer.QuestionId, out var personaIndexByOption))
                continue;

            if (answer.OptionIndex < 0 || answer.OptionIndex >= personaIndexByOption.Length)
                continue;

            var personaIdx = personaIndexByOption[answer.OptionIndex];

            if (personaIdx < 0 || personaIdx >= personaNames.Length)
                continue;

            var personaName = personaNames[personaIdx];
            scores[personaName]++;
        }


        var max = scores.Values.DefaultIfEmpty(0).Max();
        var winners = scores.Where(kv => kv.Value == max).Select(kv => kv.Key).ToList();


        var topName = winners.OrderBy(name => Array.IndexOf(personaNames, name)).First();

        return new QuizResult(catPersonas.First(p => p.Name == topName), scores);
    }
}