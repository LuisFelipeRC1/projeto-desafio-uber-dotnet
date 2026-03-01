namespace Domain
{
    public sealed record MovieLocation
    {
        public string Title { get; }
        public int ReleaseYear { get; }
        public string Locations { get; }
        public string Director { get; }
        public string Actor_1 { get; }
        public string Actor_2 { get; }
        private string Actor_3 { get; }

        public MovieLocation(string title, int releaseYear, string locations, string director, string actor_1, string actor_2, string actor_3)
        {
            validation(title, releaseYear, locations, director, actor_1, actor_2, actor_3);
            Title = title;
            ReleaseYear = releaseYear;
            Locations = locations;
            Director = director;
            Actor_1 = actor_1;
            Actor_2 = actor_2;
            Actor_3 = actor_3;
        }

        private void validation(string title, int releaseYear, string locations, string director, string actor_1, string actor_2, string actor_3)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("O título do filme é obrigatório.");
            }

            if (releaseYear <= 0)
            {
                throw new ArgumentException("O ano de lançamento deve ser um número positivo.");
            }

            if (string.IsNullOrWhiteSpace(locations))
            {
                throw new ArgumentException("As locações do filme são obrigatórias.");
            }

            if (string.IsNullOrWhiteSpace(director))
            {
                throw new ArgumentException("O diretor do filme é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(actor_1))
            {
                throw new ArgumentException("O primeiro ator do filme é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(actor_2))
            {
                throw new ArgumentException("O segundo ator do filme é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(actor_3))
            {
                throw new ArgumentException("O terceiro ator do filme é obrigatório.");
            }
        }
    }
}