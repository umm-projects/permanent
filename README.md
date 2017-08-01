# What?

* 永続 GameObject を束ねる親として Hierarchy の上位に配置する GameObject
* このクラス単体で使うコトは殆どないかな？

# Why?

* Garbage Collection の際に親 GameObject を破棄するだけで済むようにしたかった

# Install

```shell
$ npm install @umm/permanent
```

# Usage

```csharp
public class Hoge : MonoBehaviour {

    public void Start() {
        Permanent.Add(this);
    }

}
```

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

