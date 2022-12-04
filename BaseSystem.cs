using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Jam_Game
{
    class BaseSystem<T> where T : Component
    {
        protected static List<T> components = new List<T>();

        public static void Register(T component)
        {
            if (component != null)
            {
                components.Add(component);
            }
            
        }

        public static void Update(GameTime gameTime)
        {
            foreach (T component in components)
            {
                component.Update(gameTime);
            }
        }
    }

    class TransformSystem : BaseSystem<Transform> { }
    class SpriteSystem : BaseSystem<Sprite> { }
    class AnimatedSpriteSystem : BaseSystem<SheetSprite> { }
    class ColliderSystem : BaseSystem<Collider> { }
}
