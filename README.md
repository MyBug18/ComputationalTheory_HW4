# Computational Theory HW4 Report

## 2018320133 김민수

---

## Enviornment

- OS: Windows 10
- Tool: Visual Studio Code
- Language: C#
- Library: [System.Text.RegularExpressions](https://docs.microsoft.com/ko-kr/dotnet/standard/base-types/regular-expressions)

---

## Explanation

This program consists of two files: a file with Main function, and with Matcher class. Matcher class provides every functionality to implement HW4 requirements: patterns, functions.

### Student ID matching

The pattern for matching student ID looks like this: `"^\d{4}320\d{3}$"`. It's pretty trivial to figure out it's functionality, but let me explain it. First letter `^` and last letter `$` is for matching start and end of the line. What matters is middle 3-digit number, which means that first 4 digit (`\d{4}`) and last 3 digit (`\d{3}`) is not important at all. So just using `\d` would be sufficient. For example, When matching 2018320133, 2018 matches with `\d{4}`, 320 matches with `320`, 133 matches with `\d{3}`. We don't need to capture value, so just determining whether if match successes or not is enough.

### Network Packet Matching

The pattern for matching Network Packet looks like this: `^(.{12})(.{12})(.{4})"`. Now we have `Groups`, which appears with parentheses. With groups, we can capture values from the input string. When matching a string, a first group (group index 0) is always a match itself, so in our case, destination MAC is group index 1, source MAC is group index 2, and type is group index 3. After matching & slicing & capturing these values, all we have to do is just validating it by comparing with validation cases.

### SNN Matching

the pattern for matching SNN looks like this: `"^(\d\d)(\d\d)(\d\d) \- (\d)(\d\d\d\d)(\d)(\d)$"`. I already explained about groups above, so I'm sure that this pattern looks trivial. Each group contains informations in SNN. All I have to do is validate SNN with this informations.
