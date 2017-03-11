namespace VideoManagerDomain
{
    public class ActorDto
    {
        public int ActorId { get; private set; }
        public string ActorName { get; private set; }

        public ActorDto(int actorId, string actorName)
        {
            ActorId = actorId;
            ActorName = actorName;
        }
    }
}