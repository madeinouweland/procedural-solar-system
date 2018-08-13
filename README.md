# procedural-solar-system
Create our solar system procedurally with C# and Unity

![animated solar system](https://github.com/madeinouweland/procedural-solar-system/blob/master/solar.gif)

![solar system](https://github.com/madeinouweland/procedural-solar-system/blob/master/solar.png)

```
private void Start()
    {
        _renderer = new BodyRenderer(() => Instantiate(BodyPrefab));

        _sun = new Body("Sun", "#ffff00".ToColor(), 0, 1, 0, 1f);

        _sun.Children.Add(new Body("Mercurius", "#95594c".ToColor(), 2, .1f, .6f, .9f));
        _sun.Children.Add(new Body("Venus", "#8539b1".ToColor(), 3, .12f, .2f, .8f));

        _sun.Children.Add(new Body("Aarde", "#3996e8".ToColor(), 3.7f, .2f, .4f, .7f)
        {
            Children = {
                new Body("Maan","#555c57".ToColor(), .3f, .05f,  .8f, .15f)
            }
        });

        _sun.Children.Add(new Body("Mars", "#b92014".ToColor(), 4.5f, .13f, .3f, .8f)
        {
            Children = {
                new Body("Phobos", "#555c57".ToColor(),.2f, .04f,  .5f, .15f) ,
                new Body("Deimos", "#555c57".ToColor(),.22f, .03f,  .6f, .15f)
            }
        });

        var jupiter = new Body("Jupiter", "#c76420".ToColor(), 6f, .6f, .2f, .6f);
        _sun.Children.Add(jupiter);

        for (int i = 0; i < 69; i++)
        {
            jupiter.Children.Add(new Body("JM" + i, "#555c57".ToColor(), .6f + i * .01f, .04f, Random.Range(.2f, .7f), .2f));
        }

        _renderer.Create(_sun);
    }
```
