#!/usr/bin/perl -
use strict;
use warnings;

my $lockFile = "count.loc";
my $dataFile = "count.dat";
my $tempFile = "count.$$";
my $resultId = 0;

if (open(LOCK, "> $lockFile") && flock(LOCK, 2)) {
	if (open(IN, $dataFile) && flock(IN, 1)) {
		$resultId = <IN>;
		close(IN);
		if (open(OUT, "> $tempFile") && flock(OUT, 2)) {
			print OUT $resultId+1;
			close(OUT);
			rename($tempFile, $dataFile);
		} else { $resultId = -3; }
	} else { $resultId = -2; }
	close(LOCK);
} else { $resultId = -1; }
print "Content-Type: text/html\n\n";
print qq|<html><head><title></title></head><body>$resultId</body></html>|;
