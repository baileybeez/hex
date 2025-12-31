# Hex

Hex is an esoteric programming language for writing elegant programs in arcane symbols. Currently, the CLI is implemented in C#, but the longer term plan is to re-implement it in Hex itself. Additionally, the goal is to offer compilation to native executables.

> [!WARNING]
> Hex is an evolving project and is subject to functionality and/or syntax changes at any moment. Hex is far from complete and the CLI may crash or be missing features. Keep your expectations low.

![CI Tests](https://github.com/baileybeez/hex/actions/workflows/dotnet.yml/badge.svg)

### Milestones

- [x] REPL
- [x] CLI offering ability to emulate codex files.
- [ ] support for compilation to IR files
- [ ] compilation to machine code
- [ ] self-hosted compiler

## Getting Started

To get started using Hex, you'll need .NET 10. All of Hex can be easily built by running `dotnet build` from the terminal. Then, you can interact with all the tools via the CLI: 

```console
> hex help
```

## Examples

You can run any of the included examples via the CLI: 
```console
> hex invoke [codex file]
```

### A [simple program](./examples/simple_add.codex) to add two numbers together and display the result.
```utf-8
𝜙⚝ ᛗᚫᛇᚾ → 🝗
◯⟥
   🝣 🜂 🜔 ᚫ ← 1
   🝣 🜂 🜔 ᛒ ← 1

   🝣 🜂 🜔 ᛇ ← ᛒ + ᚫ
   ⯝ ᛇ
⟤
```

## Language Reference

> [!WARNING]
> Hex is still in its infancy. Any documentation in this section may be outdated and is subject to change without notice.

### I. Identifiers

All identifiers (functions and variables) **must** be named with the a _slightly_ Elder Furthark Runic Alphabet. Those runes are as follows: 
```
utf-8
ᚫ ᛒ ᚦ ᛞ ᛖ ᚠ ᚷ ᚺ ᛇ ᛃ ᚲ ᛚ ᛗ ᚾ ᛟ ᛈ ᛰ ᚱ ᛊ ᛏ ᚢ ᚹ ᛝ ᚯ ᛸ ᛉ
```

### II. Variables

Variables must be conjured (`🝣`) into the active ritual circle. To conjure a variable you must then express your intentions for the purpose of the variable. Purposes include both the modifier (e.g. volitile, constant) and the type (e.g. U64, Bool, etc). When conjuring, you can optionally provide an initial value for the variable. 

#### Flags
   - 🜂    Fire is volitile and allowed to change
   - 🜃    Earth is constant

#### Types
   - 🝗    Ash is a void value
   - 🜔    Salt is an unsigned 64-bit integer value

#### Examples
```utf-8
🝣 🜂 🜔 ᛒ           "conjure fire salt ᛒ"
🝣 🜃 🜔 ᚠᛟᛟ ← 1     "conjure fire salt ᚠᛟᛟ as 1"
```

### III. Rituals

Ritual circles are required to perform any and all work in Hex. Rituals (`⚝`) are designated by providing a name and what they intend to manifest. Once defined, you may conjure (`🝣`) a working space for your ritual. You must issue instructions for what reagents are required by anyone wishing to invoke this ritual. Only afterwards can you cast the circle (`◯`) and begin the ritual work. All ritual work must be contained between scope markers (`⟥` and `⟤`). A value may be manifested (`🝑`) from the ritual.

An entry point (required for code outside of the REPL) can be designated by prefixed the ritual marker with The Fool (`𝜙`).

#### Working Spaces
   - 🝥    Cauldron

#### Reagents

Instructions for each reagents must include placing (`🝀`) the variable (see above). In addition, each working space may require additional information: 
   - Cauldrons must be stirred between reagents, either clockwise (`↷`) or couter-clockwise (`↶`)

#### Declaraction Example
```utf-8
⚝ ᚫᛞᛞ → 🜔 
🝣🝥
   🝀 🜂 🜔 ᚫ ↷
   🝀 🜂 🜔 ᛒ ↷
◯⟥
   🝑 ᛒ + ᚫ
⟤
```

### IV. Ritual Invokation

Definied rituals may be invoked at any time by conjuring (`🝣`) the proper workspace, placing (`🝀`) the proper reagents (see Reagent information above), and then invoking (`🝠`) the ritual. The work space and reagent manipulation **must** match the definied ritual or the invokation will fail (e.g. a ritual that uses a cauldron must be invoked with a cauldron).

#### Invokation Example
Invoking the ritual `ᚠᛟᛟ` after placing `ᚷ` into the cauldron and stirring clockwise.
```utf-8
🝣 🝥
🝀 ᚷ 🝥 ↷
🝠 ᚠᛇᛒ
```
