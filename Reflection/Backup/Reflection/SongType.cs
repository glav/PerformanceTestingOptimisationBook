using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection
{
    public enum SongType
    {
        [DescriptiveTitle("Contemporary Rock")]
        Rock,
        [DescriptiveTitle("Pop, Teeny Bopper")]
        Pop,
        [DescriptiveTitle("Rap and Hip Hop")]
        Rap,
        [DescriptiveTitle("Heavy Metal")]
        HeavyMetal,
        [DescriptiveTitle("Classical and Opera")]
        Classical
    }
}
