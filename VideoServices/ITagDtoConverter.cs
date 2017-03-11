using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public interface ITagDtoConverter
    {
        Tag TagDtoToTag(TagDto TagDto);
        TagDto TagToTagDto(Tag Tag);
    }
}