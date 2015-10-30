#!/usr/bin/perl --
use strict;
use warnings;


BEGIN {
  $SIG{__DIE__} = sub {
    print "content-type: text/html; charset=UTF-8\n\n";
    print "<html><head>";
    print "<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">";
    print "<style type=\"text/css\">";
    print "<!--\n";
    print "*{font-size:10pt\;color:#C66\;font-weight:bold;line-height:1.6;}";
    print "//-->";
    print "</style>";
    print "</head><body>";
    print $_[0];
    print "</body></html>";
    CORE::die(@_);
  };
}


use Encode qw/decode encode/;
use Digest::SHA qw/sha512_hex/;


my $server_script = "http://".$ENV{'SERVER_NAME'}.$ENV{'SCRIPT_NAME'};


my $hkey = "b8e7ae12510bdfb1812e463a7f086122cf37e4f7fb1812e463a7f0";


my %login_info = (
  "demo" => {"password" => "test", "directory" => "download"},
);


my %images_gif = (
  "back"   => "data:image/gif;base64,R0lGODlhEwATAKIAAP///8zMzJmZmWZmZjMzMwAAAP///wAAACH5BAUUAAYALAAAAAATABMAAANMaLrc/jDKSSsEYYwArBhEGFAYGBJDFwHfGQpTdgpBsS5CDtpPQHC5UGHYIxROwySPITAqnwOH8zlEqRiAgTI0oF0d2q4AQ8mMLOhFAgA7",
  "home"   => "data:image/gif;base64,R0lGODlhEwATAOYAADczeYfC9PFwBoe67IGNv/W6hO7//7Z1YK2MkeDu+M66kPKXZ6RKQsne+PDq68LG2v+sQ7e6u7Sfj7TX9v/zyXmo4FhQkvqmPKwMAeLJy/y2XbbF4//VlPDv9OqGZX2IsZqlyJ/V/KPP68zEyePp9eLf6PyJEf/NVpSPvP7HkteunXF1ppehx7jc8J3D39Pm9cfi8efx+Jmfw//FT7e72a+31czKrejIt4yWuPf09eObaLPo/PzYq/+tSkpEg/vHi4ebyZXF9f3275ScvP6dKP////+UJJHH7uPV0b3Q5v/MZv/HWdjw+87m///WpKjp///Mma3b75Kx0Ob39/+xPP6lMb/g9P+8UvD1/8vi87vD39/v/vf3/4XR//u/iuTk49uom73j9v/Lgo+bvJOawt3q9ebv///IX7+/1cTj9YSPt5+mzZvc/5/H6M/g8qWex5KXufy0S/+ZM57G7b/V6f7Roer1/f+zQN73/wAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAQUAP8ALAAAAAATABMAAAe7gEWCg4SFhoeIiYqLjINCghkMKow8GhwUYBgei3VVdzNLcQILij9EV0pKEFViOjeITlWoZxBGUEVIB0iGPFRLSrRGKUVYBiMIDoVfCidXtV5FXDEJTGhvhQlzNhcmBcR2ZW5uaTKFJCJPERIvxForYzBWQ+ZtO2xdTVh2ZAAfVi3zCHFJciREkAYxtrDwoSZMFByGcmwYEMAKNRAWCLiQAgeRlgoTXtBZg4LGgxIdEtUAQgYNiRyNYhYJBAA7",
  "file"   => "data:image/gif;base64,R0lGODlhEwATAMQAAPv7+/f39/Pz8+/v7+rq6ubm5uLi4t7e3tra2tbW1tLS0s7OzsrKysXFxcHBwb29vbm5ubW1tbGxsa2trampqaWlpaCgoJSUlP///wAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAUUABgALAAAAAATABMAAAWZICaOZGmeaKqubEsKwiDPMgyYztI0zt4suQjBJCEMBIAALHCMGEwTA2UiuUyulELlABUkEAVDAYFIDCzP0qRAjUjckXUlTZoMvoZ84WCeQwsRERCDEBQRWnQjdgwLCY4JCwwDfmoEPQuYCw8MGBUJUAMOoqMNDwAVCCYUAxiQmZgEEgomEANJMLgwEKklDw8SwMESEw4UiSIhADs=",
  "new"    => "data:image/gif;base64,R0lGODlhFgAMAPkAMQAAAP8A/wAAAAAAACH/C05FVFNDQVBFMi4wAwEAAAAh+QQJBQAAACwAAAIAFgAKAAACJ4SPqRDtD2MTtNp7Z6j7if6F2iZa4HmKU4mGH8iVlBZ7kIrlucTzBQAh+QQJCgAAACwAAAEAFgAKAAACJ4SPqRDtD2MTtNp7Z6j7if6F2iZa4HmKU4mGH8iVlBZ7kIrlucTzBQAh+QQJCgAAACwAAAEAFgAKAAACJ4yPqSbtDyELjiJhsZ50vwyCG+OFGpZVXjOpVzJGsrzUNYDn+s4DBQAh+QQFCgAAACwAAAIAFgAJAAACIoyPqSbtDyELjiJhsZ50vwyCG+OFGpZVXjOpVzJGsrzUdYEAOw==",
  "folder" => "data:image/gif;base64,R0lGODlhEwATAOYAAI1tD+TDUVpkzMmjKBoZa83F7woISnt4k+HLlLCt0rycQcWnUM7V/2dw///4sf/qlGZmZv/3Vquo/9K1PJOOsZ6DMK+jlf/Za////zMzZp2MckM/epSh/+Ths//YYNWxc+/erJh7J9SoL9u6Q///vrutvOW4YP//mXaB5ywlOZ+Inf//zL6VJMiiOoyY///JTvC/Qv//fJmZzKp+C+rv////ZtGyaignhqyy///taeTFfnZ1xTs2S0tQiublztO3QdrS5v/84//zgf/JXMmrStqtMP/jYN7g/xAPXcqxsv//jHx8oe3GYua6VKmSm7+bL///9//mbf26P///cpl7J96+dra43ZmZ/9SsNv//Xv7aWNCrNtK0YrW+/9u3OuC8S9i1TcyjJ//LXP//tD8+gv//h52c0wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAUUABgALAAAAAATABMAAAexgBiCg4SFhoeIiYqLjI2LRwRLjoJHZEhmiSCaUIIMGxk3MocIHx9cOkEYVikUOwajgw5MURo8Cz49h1BTEVljHVUQBzMPNIc5W2BfFgIoDQdECk2chRctGEBXVwkSBUIrTxWGYj8kSV2COCUvJAEAhkMTSiYSHC5XNlJlXlTjE2M1Pqhw8iGGFiUjQhjyUC5HDiNGcpyAcSKhIRYDJogQUaRjkTBYwvQzFKKkyZMKDQUCADs=",
);


my %cookies = (
  "cu" => "",#current_user-sha512_hex
);
foreach (split(/;/,$ENV{'HTTP_COOKIE'})) {
  my ($k, $v) = split(/=/, $_);
  $k =~ s/ //;
  $cookies{$k} = $v;
}


my %form = (
  "cd" => "",#change-directory
  "cm" => "",#current_mode
  "cf" => "",#current_file
  "cu" => "",#current_user
  "cp" => "",#current_pass
  "ut" => "",#user_token
);


if ($ENV{'REQUEST_METHOD'} eq "POST") {
  my $query = "";
  read(STDIN, $query, $ENV{CONTENT_LENGTH});
  $query =~ tr/+/ /;
  $query =~ s/%([0-9A-Fa-f][0-9A-Fa-f])/pack('H2', $1)/eg;
  foreach (split(/&/, $query)) {
    my ($k, $v) = split(/=/,$_);
    $v =~ tr/+/ /;
    $v =~ s/%([a-fA-F0-9][a-fA-F0-9])/pack("C", hex($1))/eg;
    $form{$k} = $v;
  }
} elsif ($ENV{'REQUEST_METHOD'} eq "GET") {
  my $query = $ENV{'QUERY_STRING'};
  $query =~ tr/+/ /;
  $query =~ s/%([0-9A-Fa-f][0-9A-Fa-f])/pack('H2', $1)/eg;
  foreach (split(/&/, $query)) {
    my ($k, $v) = split(/=/,$_);
    $v =~ tr/+/ /;
    $v =~ s/%([a-fA-F0-9][a-fA-F0-9])/pack("C", hex($1))/eg;
    $form{$k} = $v;
  }
}

my $login_user = "";
if ($form{'ut'}) {
  $server_script.= "?ut=$form{'ut'}";
  if ($cookies{'cu'}) {
    foreach (keys(%login_info)) {
      my $hex = Digest::SHA::hmac_sha512_hex($form{'ut'}.$_, $hkey);
      if ($hex eq $cookies{'cu'}) {
        $login_user = $_;
        last;
      }
    }
  }
}


if ($login_user && $login_info{$login_user}) {
  my $root_directory = $ENV{'DOCUMENT_ROOT'};
  $root_directory =~ s/(\/.+)?\/.+$/$1\/$login_info{$login_user}{'directory'}\//;
  die "E1001：$root_directory"
    if (!(-d $root_directory));


  die "E1002：$form{'cd'}"
    if ($form{'cd'} =~ m/^\./ || $form{'cd'} =~ m/\/$/);


  if ($form{'cm'} ne "cd") {
    my $directory = "$root_directory$form{'cd'}";
    opendir(DIR, $directory) || die "E2001：$form{'cd'}";
    my @reading_list = sort grep(!/^\./, readdir(DIR));
    closedir(DIR);
    print "content-type: text/html; charset=UTF-8\n\n";
    print "<html><head>";
    print "<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">";
    print "<meta name=\"robots\" content=\"noindex,nofollow\">";
    print "<meta name=\"robots\" content=\"noarchive\">";
    print "<style type=\"text/css\">";
    print "<!--\n";
    print "*{font-size:10pt\;color:#333\;}";
    print "fieldset{padding:10px\;}";
    print "legend{font-weight:bold\;}";
    print "hr{height:1px\;}";
    print "img{border:0px\;margin:0px\;}";
    print "//-->";
    print "</style>";
    print "<title>一覧</title></head><body>";
    print "<fieldset><legend>メニュー</legend>";
    print "<img src=\"$images_gif{'back'}\" height=\"19\" width=\"19\">";
    print "<a href=\"javascript:history.back();\">戻る</a>";
    print "&emsp;";
    print "<img src=\"$images_gif{'home'}\" height=\"19\" width=\"19\">";
    print "<a href=\"$server_script\">ホーム</a>";
    print "<hr>";
    my $para_directory = "";
    foreach my $strdir (split(/\//, $form{'cd'})) {
      $strdir =~ s/([^\w ])/'%'.unpack('H2',$1)/eg;
      $para_directory = "$para_directory$strdir/";
    }
    foreach my $file_name (@reading_list) {
      my $path_file = "$directory/$file_name";
      my $para_file = $file_name;
      $para_file =~s/([^\w ])/'%'.unpack('H2',$1)/eg;
      if (-f $path_file) {
        my $files = `find "$root_directory" -name "$file_name" -type f -mtime -1`;
        if ($files) { 
          print "・ ";
          print "<img src=\"$images_gif{'file'}\" height=\"19\" width=\"19\">";
          print "<a target=\"_blank\" href=\"$server_script&cm=cd&cf=$para_directory$para_file\">$file_name</a>";
          print "&nbsp;<img src=\"$images_gif{'new'}\" height=\"12\" width=\"22\"><br>";
        } else {
          print "・ ";
          print "<img src=\"$images_gif{'file'}\" height=\"19\" width=\"19\">";
          print "<a target=\"_blank\" href=\"$server_script&cm=cd&cf=$para_directory$para_file\">$file_name</a>";
          print "<br>";
        }
      } else {
        my $files = `find "$root_directory" -name "$file_name" -type d -mtime -1`;
        if ($files) {
          print "・ ";
          print "<img src=\"$images_gif{'folder'}\" height=\"19\" width=\"19\">";
          print "<a href=\"$server_script&cd=$para_directory$para_file\">$file_name</a>";
          print "&nbsp;<img src=\"$images_gif{'new'}\" height=\"12\" width=\"22\"><br>";
        } else {
          print "・ ";
          print "<img src=\"$images_gif{'folder'}\" height=\"19\" width=\"19\">";
          print "<a href=\"$server_script&cd=$para_directory$para_file\">$file_name</a>";
          print "<br>";
        }
      }
    }
    print "</fieldset>";
    print "<hr>＊Cookieを無効にしているとログインできませんのでご注意ください！";
    print "</body></html>";
  } else {
    my $path_file = "$root_directory/$form{'cf'}";
    my @pathes = split(/\//, $path_file);
    my $save_file = Encode::encode("sjis", Encode::decode("utf8", pop @pathes));
    if ($save_file =~ /\.apk$/i) {
      print qq|Content-Type: application/vnd.android.package-archive; name="$save_file"\n|;
      print qq|Content-Disposition: attachment; filename="$save_file"\n\n|;
    } else {
      print qq|Content-type: application/octet-stream; name="$save_file"\n|;
      print qq|Content-Disposition: attachment; filename="$save_file"\n\n|;
    }
    open IN,"$path_file" || die "E3001：$form{'cf'}";
    print <IN>;
    close IN;
  }
} else {
  my $current_user = $form{'cu'};
  my $current_pass = $form{'cp'};
  if ($current_user && $current_pass) {
    foreach (keys(%login_info)) {
      if ($current_user eq $_ && $current_pass eq $login_info{$_}{'password'}) {
        my @list = ('A'..'Z', 'a'..'z', 0..9);
        my $salt = time();
        $salt.= $list[int(rand($#list))] for (1..10);
        $server_script.= "?ut=$salt";


        my $hex = Digest::SHA::hmac_sha512_hex($salt.$current_user, $hkey);
        print "Set-Cookie: cu=$hex; path=/;\n";
        print "content-type: text/html; charset=UTF-8\n\n";
        print "<html><head>";
        print "<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">";
        print "<meta http-equiv=\"refresh\" content=\"0; URL=$server_script\">";
        print "<style type=\"text/css\">";
        print "<!--\n";
        print "*{font-size:10pt\;color:#333\;}";
        print "//-->";
        print "</style>";
        print "</head><body>";
        print "<div><a href=\"$server_script\">$server_script</a></div>";
        print "<div>&nbsp;</div>";
        print "<div>＊自動的に切り替わります。（画面が切り替わらない場合はクリックして移動してください。）</div>";
        print "</body></html>";
        exit;
      }
    }
  }
  print "content-type: text/html; charset=UTF-8\n\n";
  print "<html><head>";
  print "<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">";
  print "<style type=\"text/css\">";
  print "<!--\n";
  print "*{font-size:10pt\;color:#333\;}";
  print "fieldset{padding:10px\;}";
  print "legend{font-weight:bold\;}";
  print "hr{height:1px\;}";
  print "img{border:0px\;margin:0px\;}";
  print "span{display:inline-block;width:80px;height:24px;}";
  print "//-->";
  print "</style>";
  print "</head><body>";
  print "<fieldset><legend>ログイン</legend>";
  print "<form method=\"POST\">";
  print "<ul>";
  print "<li><span>ユーザーID</span><input name=\"cu\" value=\"".$form{'cu'}."\" type=\"text\" placeholder=\"...半角英数\" pattern=\"^[0-9A-Za-z]+\$\" required autofocus></li>";
  print "<li><span>パスワード</span><input name=\"cp\" value=\"".$form{'cp'}."\" type=\"password\" placeholder=\"...\" required></li>";
  print "</ul>";
  print "<hr>";
  print "<div><input type=\"submit\" value=\"ログイン\"></div>";
  print "</form>";
  print "</fieldset>";
  print "<hr>＊Cookieを無効にしているとログインできませんのでご注意ください！";
  print "</body></html>";
}


1;