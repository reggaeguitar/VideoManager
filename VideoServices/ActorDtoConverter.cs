using System;
using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public class ActorDtoConverter : IActorDtoConverter
    {
        public Actor ActorDtoToActor(ActorDto actorDto)
        {
            throw new NotImplementedException();
        }

        public ActorDto ActorToActorDto(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
