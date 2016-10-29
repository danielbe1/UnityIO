﻿
using NUnit.Framework;
using UnityIO;
using UnityIO.Interfaces;

public class GetFilesTests : UnityIOTestBase
{
    [Test(Description = "Check if you can find assets only at the top level in " + UNIT_TEST_LOADING_TEST_ASSETS)]
    public void GetTopLevelFiles()
    {
        // Setup our test. 
        var loadingDir = SetupAssetLoadingTest();
        // Load all our assets
        var files = loadingDir.GetFiles();
        // Should only be root level which has a total of 3 files.
        Assert.AreEqual(files.Count, 3, "There should be 3 files in the root of the testing directory");
    }

    [Test(Description = "Check if you can find assets only at the top level with filter in " + UNIT_TEST_LOADING_TEST_ASSETS)]
    public void GetRecursiveFiles()
    {
        // Setup our test. 
        var loadingDir = SetupAssetLoadingTest();
        // Get all
        var files = loadingDir.GetFiles(recursive: true);
        // Should be 10 assets
        Assert.AreEqual(files.Count, 10, "There should be 10 files in the testing directory");
    }

    [Test(Description = "Checks if you can verify if you can find only assets in the top level directory with a filter. In this case any file with the .anim extension in " + UNIT_TEST_LOADING_TEST_ASSETS)]
    public void GetTopLevelWithFilters()
    {
        // Setup our test. 
        var loadingDir = SetupAssetLoadingTest();
        // We are going to try to only find files ending with .anim
        var files = loadingDir.GetFiles(filter:"*.anim");
        // There should be four. 
        Assert.AreEqual(files.Count, 1, "There should be 1 file at the root that ends with .anim in our testing directory");
    }

    [Test(Description = "Checks if you can verify if you can find all assets with a filter. In this case any file with the .anim extension in " + UNIT_TEST_LOADING_TEST_ASSETS)]
    public void GetRecursiveWithFilters()
    {
        // Setup our test. 
        var loadingDir = SetupAssetLoadingTest();
        // We are going to try to only find files ending with .anim
        var files = loadingDir.GetFiles(filter: "*.anim", recursive:true);
        // There should be four. 
        Assert.AreEqual(files.Count, 4, "There should be 1 file at the root that ends with .anim in our testing directory");
    }

    [Test(Description = "Test to make sure the meta information about the file is correct")]
    public void GetFileMeta()
    {
        // Setup our test. 
        var loadingDir = SetupAssetLoadingTest();
        // We are going to try to only find files ending with .anim
        var file = loadingDir.GetFiles(filter: "*.anim").FirstOrDefault();
        UnityEngine.Debug.Log("Directory: " + file.Directory);
        UnityEngine.Debug.Log("Extension: " + file.Extension);
        UnityEngine.Debug.Log("NameWithoutExtension: " + file.NameWithoutExtension);
    }
}
