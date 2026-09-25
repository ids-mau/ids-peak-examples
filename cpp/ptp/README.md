# Precision Time Protocol (PTP) Example

This example shows how to configure and use Precision Time Protocol (PTP)
with connected GigE cameras.

In short, the application opens the available cameras, configures the first
camera as the only opened camera eligible to become master and the others as
slave-only, waits for synchronization, acquires images, prints buffer
timestamps, and then performs cleanup.

The first camera is expected to become master unless an external grandmaster
is present and wins the Best Master Clock Algorithm (BMCA) election. If that
happens, the first camera will synchronize as a slave, as will the other
cameras.

## Workflow

The example performs the following steps:

1. Searches for available GigE devices and opens them.
2. Configures the first opened device as the only camera eligible to become
   master; the remaining cameras are slave-only.
3. Waits up to 30 seconds for the first camera to report `Master` or `Slave`
   and for the other cameras to report `Slave`.
4. Starts image acquisition.
5. Captures multiple images per device and prints each buffer acquisition timestamp.
6. Stops acquisition and releases buffers.

If no opened camera reports `Master`, the example reports that the grandmaster
is outside the opened camera list.

## Note About Acquisition Start and PPS

`AcquisitionStart` is sent to devices one after another. While later cameras are still starting,
an incoming PPS edge can already trigger cameras that are running.

As a result, the first timestamps after startup may be offset between cameras. In practice, it can
take a few frames until all cameras are running and reacting to the same PPS pulse sequence.

When evaluating synchronization quality, it is therefore recommended to ignore the first frames
after startup and use subsequent frames once all cameras are stably running.

## Requirements

To run this example, you need:

- At least two **IDS** cameras
- [IDS peak standard Setup](https://en.ids-imaging.com/download-peak.html) version 26.06.2 or later
