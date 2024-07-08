# OTDRFile
OTDRFile is a C#/.Net library designed to read data files from OTDR measurement devices.
It is intended to enable users to efficiently read OTDR data enabling the user to build advanced tools and analytics.

OTDR file is designed to be as thin as possible, preserving the structure of the original data as much as possible, making no attemtpt to normalize data from devices manufactured by different vendors.

The implementation is split into three core sections: 
- DataTypes - Holds raw data in data scructures that are as close to the binary file format as possible.
- Implementation - Wraps the DataTypes with scructures that apply the relevent scaling factors and converts fixed-point decimals into double-precision floats..
- Internal - Provides helper layers, constants, and extensions to improve the efficiency of the data parsing.

A later version of this library will enable the writing of OTDR data files, but at the moment that is a low priority.

## What is OTDR?
Optical Time Delay Reflectometry (OTDR) is a technique for characterising fibreoptic cables and detecting faults within them.

OTDR is used by Fibre Technicians to ensure that they have correctly provisioned a new connection, or to help localize faults in a broken one.

It works by sending a bright pulse of light down the fibre and measuring the backscatter (light reflected back up the fibre from nanoscopic impurities) as the light travels down the fibre, enabling it to calculate the signal loss across the length of the fibre.
With events like Breaks and Coupling blocks cause spikes in fresnel reflectance (mirror-like reflectance) and high losses in signal level, which can be detected from the characteristic spike in the signal followed by a strong drop in the signal. 
Whereas events such as bad splices and bends cause high dispersion (some wavelengths experiencing more loss than others) and high losses in signal level, which can be detected through a characteristic sudden drop in signal strength.

OTDRs enable technicians to measure a fibre from each end to find issues that need repairing and confirming if the fibre is within spec and ready for service.

## Standards and compliance
OTDRFile provides the ability to read data compliant with OpenSOD(RFC 0001).
It should also be able to load SOR data compliant with SR-4731 (Issues 1 & 2), but as we have never seen SR-4731, or any derrivatives thereof, we cannot verify this.

## Disclaimer
This library is written without knowledge of Ericsson’s (or any other rights holder’s) intellectual property and has been constructed independently by the Authors. Any compatibility with the Standard OTDR Record as defined by SR-4731 (Issue 2) or any derivative or preceding works thereof is circumstantial and is not guaranteed by the authors. 

Using this library with the intent of being compliant with any formats other than the format defined by OpenSOD RFC 0001 is at your own risk.

If readers require a library that is fully compatible with the SOR format as defined by SR-4731 (or derivatives), then they should purchase the relevant documents from the rights holders of that standard.

## License
The software in this repository is released under the Apache License 2.0. 
A copy of this license has been provided in the file `LICENSE.md`.
For a helpful summary of the license check out: https://choosealicense.com/licenses/apache-2.0/

## Copyright Statement
Copyright 2024 BaldrAI Ltd.

## Usage

The recommended way to use the library is through the `OTDRFile` class, which parses the `byte[]` in parallel and provides a clean interface to the data with all scaling factors and relevant conversions applied.

```c#
var otdrFile = new OTDRFile(data);
Console.WriteLine(string.Format("{0} => {1} ({2} / {3})", otdrFile.GenParams.LocationA, otdrFile.GenParams.LocationB, otdrFile.GenParams.Wavelength, otdrFile.GenParams.FiberType));
```
