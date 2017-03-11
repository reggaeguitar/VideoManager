using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public interface IActorDtoConverter
    {
        Actor ActorDtoToActor(ActorDto actorDto);
        ActorDto ActorToActorDto(Actor actor);
    }
}