using System.Collections.Generic;
using System.Linq;
using NzbDrone.Core.Profiles.Qualities;
using Lidarr.Http.REST;

namespace Lidarr.Api.V1.Profiles.Quality
{
    public class QualityProfileResource : RestResource
    {
        public string Name { get; set; }
        public int Cutoff { get; set; }
        public List<QualityProfileQualityItemResource> Items { get; set; }
    }

    public class QualityProfileQualityItemResource : RestResource
    {
        public string Name { get; set; }
        public NzbDrone.Core.Qualities.Quality Quality { get; set; }
        public List<QualityProfileQualityItemResource> Items { get; set; }
        public bool Allowed { get; set; }

        public QualityProfileQualityItemResource()
        {
            Items = new List<QualityProfileQualityItemResource>();
        }
    }

    public static class ProfileResourceMapper
    {
        public static QualityProfileResource ToResource(this Profile model)
        {
            if (model == null) return null;

            return new QualityProfileResource
            {
                Id = model.Id,
                Name = model.Name,
                Cutoff = model.Cutoff,
                Items = model.Items.ConvertAll(ToResource)
            };
        }

        public static QualityProfileQualityItemResource ToResource(this ProfileQualityItem model)
        {
            if (model == null) return null;

            return new QualityProfileQualityItemResource
            {
                Id = model.Id,
                Name = model.Name,
                Quality = model.Quality,
                Items = model.Items.ConvertAll(ToResource),
                Allowed = model.Allowed
            };
        }

        public static Profile ToModel(this QualityProfileResource resource)
        {
            if (resource == null) return null;

            return new Profile
            {
                Id = resource.Id,
                Name = resource.Name,
                Cutoff = resource.Cutoff,
                Items = resource.Items.ConvertAll(ToModel)
            };
        }

        public static ProfileQualityItem ToModel(this QualityProfileQualityItemResource resource)
        {
            if (resource == null) return null;

            return new ProfileQualityItem
            {
                Id = resource.Id,
                Name = resource.Name,
                Quality = resource.Quality != null ? (NzbDrone.Core.Qualities.Quality)resource.Quality.Id : null,
                Items = resource.Items.ConvertAll(ToModel),
                Allowed = resource.Allowed
            };
        }

        public static List<QualityProfileResource> ToResource(this IEnumerable<Profile> models)
        {
            return models.Select(ToResource).ToList();
        }
    }
}
