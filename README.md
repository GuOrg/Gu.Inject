# Gu.Inject

[![Join the chat at https://gitter.im/JohanLarsson/Gu.Inject](https://badges.gitter.im/JohanLarsson/Gu.Inject.svg)](https://gitter.im/JohanLarsson/Gu.Inject?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
Playing around with writing an IoC

[![Build status](https://ci.appveyor.com/api/projects/status/c51yih3egb6lik1n/branch/master?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-inject/branch/master)

Goal is to make a simple fast container enforcing sane conventions.

- Ctor injection only. Maybe support for circular messes via initialize but there goes sanity.
- Only one ctor, can be private.
- Wire up interfaces & inheritance automatically for 1 : 1
- Allow explicit bindings. Throw if there is a binding.
- Allow Rebind, throw if kernel has resolved.
- Dispose and clear all things, don't leak.
