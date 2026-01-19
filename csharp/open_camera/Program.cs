/*!
 * \file    Program.cs
 * \author  vapivendorname
 * \date    2021-03-05
 *
 * \brief   This application demonstrates how to use the device manager to open a camera
 *
 * Copyright (C) @[[COPYRIGHT_YEAR(2020)]], vapivendorname.
 *
 * The information in this document is subject to change without notice
 * and should not be construed as a commitment by vapivendorname.
 * vapivendorname does not assume any responsibility for any errors
 * that may appear in this document.
 *
 * This document, or source code, is provided solely as an example of how to utilize
 * vapivendorname software libraries in a sample application.
 * vapivendorname does not assume any responsibility
 * for the use or reliability of any portion of this document.
 *
 * General permission to copy or modify is hereby granted.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace open_camera
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String projectName = "open_camera";
                String version = "v1.1.1";

                Console.WriteLine("vapiproductname " + projectName + " Sample " + version);

                // The library must be initialized before use.
                // Each call to `Initialize` must be matched with a corresponding call to `Close`.
                vapinamespace.Library.Initialize();

                // Get the device manager singleton object.
                var deviceManager = vapinamespace.DeviceManager.Instance();

                // Update the device manager.
                // When `Update` is called, it searches for all
                // ProducerLibraries found in the directories
                // specified by the GENICAM_GENTL{32/64}_PATH environment
                // variable. It then opens all producers,
                // their systems and interfaces, and lists all available
                // DeviceDescriptors.
                deviceManager.Update();

                // Exit program if no device was found.
                if (!deviceManager.Devices().Any())
                {
                    Console.WriteLine("No device found. Exiting program.");
                    Console.ReadKey();
                    // One call to `Close` is required for each call to `Initialize`.
                    vapinamespace.Library.Close();
                    return;
                }

                // List all available devices.
                uint i = 0;
                Console.WriteLine("Devices available: ");
                foreach (var deviceDescriptor in deviceManager.Devices())
                {
                    Console.WriteLine(i + ": " + deviceDescriptor.ModelName() + " ("
                              + deviceDescriptor.ParentInterface().DisplayName() + "; "
                              + deviceDescriptor.ParentInterface().ParentSystem().DisplayName() + " v."
                              + deviceDescriptor.ParentInterface().ParentSystem().Version() + ")");
                    ++i;
                }

                // Select a device to open.
                int selectedDevice = 0;
                // Prompt user for device index or remove this block to always use the first device.
                Console.WriteLine("\nSelect device to open: ");
                selectedDevice = Convert.ToInt32(Console.ReadLine());

                // Open the selected device with control access.
                // The access types correspond to the GenTL `DEVICE_ACCESS_FLAGS`.
                var device = deviceManager.Devices()[selectedDevice].OpenDevice(vapinamespace.core.DeviceAccessType.Control);

                // Retrieve the remote device's primary node map.
                // In GenICam, a node map represents a hierarchical set of parameters (features)
                // such as exposure, gain, and firmware info. The node map provides access to controls
                // implemented on the device itself, typically following the GenICam SFNC, while allowing for
                // device-specific extensions.
                var nodeMapRemoteDevice = device.RemoteDevice().NodeMaps()[0];

                try
                {
                    // Print model name using the "DeviceModelName" node.
                    Console.WriteLine("Model Name: " + nodeMapRemoteDevice.FindNode<vapinamespace.core.nodes.StringNode>("DeviceModelName").Value());
                }
                catch (Exception)
                {
                    // If "DeviceModelName" is not a valid or implemented node.
                    Console.WriteLine("Model Name: (unknown)");
                }

                try
                {
                    // Print user ID using the "DeviceUserID" node.
                    Console.WriteLine("User ID: " + nodeMapRemoteDevice.FindNode<vapinamespace.core.nodes.StringNode>("DeviceUserID").Value());
                }
                catch (Exception)
                {
                    Console.WriteLine("User ID: (unknown)");
                }

                try
                {
                    // Print sensor information using the "SensorName" node.
                    Console.WriteLine("Sensor Name: " + nodeMapRemoteDevice.FindNode<vapinamespace.core.nodes.StringNode>("SensorName").Value());
                }
                catch (Exception)
                {
                    Console.WriteLine("Sensor Name: (unknown)");
                }

                try
                {
                    // Print maximum sensor resolution (width x height).
                    Console.WriteLine("Max. resolution (w x h): "
                          + nodeMapRemoteDevice.FindNode<vapinamespace.core.nodes.IntegerNode>("WidthMax").Value() + " x "
                          + nodeMapRemoteDevice.FindNode<vapinamespace.core.nodes.IntegerNode>("HeightMax").Value());
                }
                catch (Exception)
                {
                    Console.WriteLine("Max. resolution (w x h): (unknown)");
                }

                // Dispose objects no longer needed.
                nodeMapRemoteDevice?.Dispose();
                nodeMapRemoteDevice = null;

                device?.Dispose();
                device = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: " + e.Message);
            }

            // One call to `Close` is required for each call to `Initialize`.
            vapinamespace.Library.Close();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            Environment.ExitCode = 0;
            return;
        }
    }
}

