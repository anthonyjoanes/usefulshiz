# Oracle Virtual Machine

## Extending the storage


1. Shutdown the virtual machine
2. Get the location of the drive for the machine (Do this from manager)
3. Use the below commands from the command line

```
VBoxManage modifyhd "path to the VDI" --resize 81920
```

[Helpful Link](https://www.howtogeek.com/124622/how-to-enlarge-a-virtual-machines-disk-in-virtualbox-or-vmware/)
