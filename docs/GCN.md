# Grqphical Compact Notation 1.0

Grqphical compact notation or GCN is a format I created to store data in the most compact way possible. It's meant to be used on systems with low storage space or to create smaller save data files.

## File Format

GCN is made up of chunks of integers seperated by semicolons. You can choose the size of these integer chunks.

An Example of GCN with a chunk size of 3 is:

```3000;012;119;987;```

The first character in GCN data reprsents the chunk size. NOTE: Currently The chunk size cannot be larger than 9.

## Version History
No prior Versions yet