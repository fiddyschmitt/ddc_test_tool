# ddc_test_tool

A test tool for DDC/CI, to help determine if a monitor supports changing inputs.
Windows only.

# Download
Download from the [releases](https://github.com/fiddyschmitt/ddc_test_tool/releases) section.

# Usage

## List all monitors:

`ddc_test_tool list`

<img src="https://i.imgur.com/7YcPZL5.png">

## Change monitor input:

`ddc_test_tool set-source --monitor 1 --source 18`

Where source is typically one of the following values:

```
1 = VGA 1
2 = VGA 2
3 = DVI 1
4 = DVI 2
5 = Composite video 1
6 = Composite video 2
7 = S-Video 1
8 = S-Video 2
9 = Tuner 1
10 = Tuner 2
11 = Tuner 3
12 = Component video (YPrPb/YCrCb) 1
13 = Component video (YPrPb/YCrCb) 2
14 = Component video (YPrPb/YCrCb) 3
15 = DisplayPort 1
16 = DisplayPort 2
17 = HDMI 1
18 = HDMI 2
```
It's worth trying other values, as someone mentioned that 27 was USB-C on their monitor.
