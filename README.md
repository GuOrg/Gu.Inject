# Gu.Inject

A dependency injection library with no features. The lack of features is the main feature!

[![Build status](https://ci.appveyor.com/api/projects/status/c51yih3egb6lik1n/branch/master?svg=true)](https://ci.appveyor.com/project/GuOrg/gu-inject/branch/master)
[![Build Status](https://dev.azure.com/guorg/Gu.Inject/_apis/build/status/GuOrg.Gu.Inject?branchName=master)](https://dev.azure.com/guorg/Gu.Inject/_build/latest?definitionId=2&branchName=master)
[![Join the chat at https://gitter.im/JohanLarsson/Gu.Inject](https://badges.gitter.im/JohanLarsson/Gu.Inject.svg)](https://gitter.im/JohanLarsson/Gu.Inject?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# Defaults

- Concrete types with one constructor are resolved by default.
  - One public constructor.
  - Params parameter not supported.
  - Class.
- Everything from the container is singleton.
- Constructor injection only unless providing custom factory functions.
- Require explicit bindings for interfaces and abstract types. Only one binding per type.
- Rebind shipped in a separate nuget to enforce that it is only used by tests.
- Dispose all things created by the container.

# Usage

```cs
using var kernel = new Kernel();
var root = kernel.Get<RootType>();
```

## Bind interface

```cs
using var kernel = new Kernel()
    .Bind<IFoo, Foo>();
var root = kernel.Get<RootType>();
```

Note that:
```cs
using var kernel = new Kernel()
    .Bind<IFoo, Foo>()
    .Bind<IFoo, Bar>(); // throws binding IFoo a second time.
```

## Bind factory

```cs
using var kernel = new Kernel()
    .Bind(() => Foo.Create()); // this instance is disposed when the container is disposed
var root = kernel.Get<RootType>();
```

Also allowed:
```cs
using var kernel = new Kernel()
    .Bind<IFoo>(() => Foo.Create()); // this instance is disposed when the container is disposed
var root = kernel.Get<RootType>();
```

## Bind resolver factory

```cs
using var kernel = new Kernel()
    .Bind(c => Foo.Create(c.Get<Bar>())); // this instance is disposed when the container is disposed
var root = kernel.Get<RootType>();
```

Also allowed:
```cs
using var kernel = new Kernel()
    .Bind<IFoo>(c => Foo.Create(c.Get<Bar>())); // this instance is disposed when the container is disposed
var root = kernel.Get<RootType>();
```

## Bind instance

```cs
using var kernel = new Kernel()
    .Bind(Foo.Instance); // this instance is not disposed when the container is disposed
var root = kernel.Get<RootType>();
```

Also allowed:
```cs
using var kernel = new Kernel()
    .Bind<IFoo>(new Foo()); // this instance is not disposed when the container is disposed
```

# Benchmark

```
|         Method |        Mean |  Ratio | Allocated |
|--------------- |------------:|-------:|----------:|
|        Ninject | 4,307.95 μs | 383.59 | 236.54 KB |
| SimpleInjector | 3,467.61 μs | 308.75 | 201.13 KB |
|         DryIoc |    79.06 μs |   7.01 |  73.59 KB |
|       GuInject |    11.22 μs |   1.00 |   11.2 KB |
|  GuInjectBound |    21.52 μs |   1.91 |  22.33 KB |
```