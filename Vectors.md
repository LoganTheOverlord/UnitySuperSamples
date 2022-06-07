There are some simple things I wish people knew. Let's share them!

First of all, you don't have to establish a new Vector3(1,1,1) to make things exactly one on scale, for example.
You can use Vector3.one and it returns the same result.
Same thing goes for Vector3.zero

Additionally, you don't have to create direction vectors, that are diagonal.
those are:

- Vector3.left
- Vector3.right
- Vector3.forward
- Vector3.back
- Vector3.up
- Vector3.down

You can use this as this:
rigidbody.AddForce(Vector3.left * 5f + Vector3.up * 10f);

This would launch object into air towards left. It's that simple.
You can of course combine and multiply these vectors.

Also, transform has similar functions.

You can use:

> transform.right
> transform.forward
> transform.up
And it's negatives to get opposite direction. This is extremely useful to push objects, or change position in transform's relative direction vectors.
Example:
> transform.position += transform.forward * speed;
This would "push" object forward exactly 5 meters (units)
