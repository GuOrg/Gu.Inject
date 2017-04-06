# Gu.Inject
Playing around with writing an IoC

Goal is to make a simple fast container enforcing sane conventions.

- Ctor injection only. Maybe support for circular messes via initialize but there goes sanity.
- Only one ctor, can be private.
- Wire up interfaces & inheritance automatically for 1 : 1
- Allow explicit bindings. Throw if there is a binding.
- Allow Rebind, throw if kernel has resolved.
- Dispose and clear all things, don't leak.
